﻿namespace Skyline.DataMiner.CICD.Models.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Text;

    using Skyline.DataMiner.CICD.Models.Common;
    using Skyline.DataMiner.CICD.Models.Protocol.Models.Custom_Classes.Protocol.QAction;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;

    /// <summary>
    /// Represents the model of the compiled QActions.
    /// </summary>
    public class QActionCompilationModel
    {
        private static readonly string[] Preprocessors = { "DCFv1", "ALARM_SQUASHING", "DBInfo" };
        private static readonly Regex QActionRegex = new Regex(@"\[ProtocolName\]\.\[ProtocolVersion\]\.QAction\.(?<id>[\d]+)\.dll", RegexOptions.Compiled);

        private static readonly IEnumerable<string> DefaultReferencedAssemblies;

        private readonly IProtocolModel protocolModel;

        private readonly string qactionHelperSourceCode;

        private readonly IAssemblyResolver dllImportResolver;
        private List<MetadataReference> defaultReferences;

        private readonly Solution existingSolution;
        private bool solutionCreationFailed;

#pragma warning disable S3963 // "static" fields should be initialized inline
        static QActionCompilationModel()
        {
            List<string> assembliesToReference = new List<string>(QActionAssemblyReferencesHelper.DefaultReferencedAssemblies);
            if (!assembliesToReference.Contains("netstandard.dll"))
            {
                assembliesToReference.Add("netstandard.dll");
            }

            DefaultReferencedAssemblies = assembliesToReference.ToArray();
        }
#pragma warning restore S3963 // "static" fields should be initialized inline

        /// <summary>
        /// Initializes a new instance of the <see cref="QActionCompilationModel"/> class.
        /// </summary>
        /// <param name="protocolModel">The protocol model.</param>
        /// <param name="solution">The solution.</param>
        public QActionCompilationModel(IProtocolModel protocolModel, Solution solution)
        {
            this.protocolModel = protocolModel ?? throw new ArgumentNullException(nameof(protocolModel));
            existingSolution = solution ?? throw new ArgumentNullException(nameof(solution));
            IsSolutionBased = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QActionCompilationModel"/> class using the specified QAction helper source code, the protocol model and the assembly resolver.
        /// </summary>
        /// <param name="qactionHelperSourceCode">The QAction helper source code.</param>
        /// <param name="protocolModel">The protocol model.</param>
        /// <param name="assemblyResolver">The assembly resolver.</param>
        public QActionCompilationModel(string qactionHelperSourceCode, IProtocolModel protocolModel, IAssemblyResolver assemblyResolver)
        {
            this.qactionHelperSourceCode = qactionHelperSourceCode;
            this.protocolModel = protocolModel;
            dllImportResolver = assemblyResolver;
        }

        /// <summary>
        /// Returns a value indicating whether the compilation model is based on an existing solution.
        /// </summary>
        /// <value><c>true</c> if the compilation model is based on an existing solution; otherwise, <c>false</c>.</value>
        public bool IsSolutionBased { get; }

        // Keep this as is, as it could be needed in the future when e.g. .NET is supported and depending on minimum required DM version a different version is used.
        private LanguageVersion CSharpLanguageVersion => LanguageVersion.CSharp7_3;

        /// <summary>
        /// Performs a build of solution. If no solution exists yet, the solution is first created form the protocol model.
        /// </summary>
        public IReadOnlyDictionary<ProjectId, CompiledQActionProject> Build()
        {
            Dictionary<ProjectId, CompiledQActionProject> projectsData = new Dictionary<ProjectId, CompiledQActionProject>();

            if (IsSolutionBased)
            {
                BuildBasedOnExistingSolution(projectsData);
            }
            else
            {
                BuildFromNewWorkspace(projectsData);
            }

            return new ReadOnlyDictionary<ProjectId, CompiledQActionProject>(projectsData);
        }

        private void BuildBasedOnExistingSolution(Dictionary<ProjectId, CompiledQActionProject> projectsData)
        {
            Dictionary<int, (ProjectId project, IQActionsQAction qa)> allProjects = new Dictionary<int, (ProjectId project, IQActionsQAction qa)>();

            Dictionary<string, Project> projectsMap = existingSolution.Projects.ToDictionary(project => project.Name);

            foreach (IQActionsQAction qAction in protocolModel.EachQActionWithValidId())
            {
                uint? qactionId = qAction.Id.Value;

                string qactionName = "QAction_" + qactionId;

                if (projectsMap.TryGetValue(qactionName, out Project project))
                {
                    allProjects.Add(Convert.ToInt32(qactionId), (project.Id, qAction));
                }
            }

            QActionProjectMap qactionProjectMap = new QActionProjectMap(existingSolution, allProjects);

            CompileQActions(qactionProjectMap, projectsData);
        }

        private void BuildFromNewWorkspace(Dictionary<ProjectId, CompiledQActionProject> projectsData)
        {
            var adhocWorkspace = new AdhocWorkspace();

            DotNetFrameworkVersion dotNetVersion = DotNetFrameworkVersion.LatestVersionFromRegistry;

            VersionStamp versionStamp = VersionStamp.Create();

            SolutionId solutionId = SolutionId.CreateNewId("solution");
            SolutionInfo solutionInfo = SolutionInfo.Create(solutionId, versionStamp);

            adhocWorkspace.AddSolution(solutionInfo);

            CreateDefaultDllReferences(dotNetVersion);

            ProjectId helperProject = null;
            if (qactionHelperSourceCode != null)
            {
                const string fileName = "QAction_Helper.cs";
                var sourceText = SourceText.From(qactionHelperSourceCode);

                helperProject = AddProject(adhocWorkspace, versionStamp, "QAction_Helper", CSharpLanguageVersion, defaultReferences);
                adhocWorkspace.AddDocument(helperProject, fileName, sourceText);
            }

            var qActions = protocolModel.EachQActionWithValidId();
            Dictionary<int, (ProjectId project, IQActionsQAction qa)> allProjects = AddProjectsToWorkSpace(qActions, adhocWorkspace, versionStamp, defaultReferences, CSharpLanguageVersion);

            AddDllImportReferences(adhocWorkspace, allProjects, helperProject, dotNetVersion, projectsData);

            QActionProjectMap solutionModel = new QActionProjectMap(adhocWorkspace.CurrentSolution, allProjects);

            if (!solutionCreationFailed)
            {
                CompileQActions(solutionModel, projectsData);
            }
        }

        private void CompileQActions(QActionProjectMap solutionModel, Dictionary<ProjectId, CompiledQActionProject> projectsData)
        {
            var solution = solutionModel.Solution;

            foreach (var projectId in solution.GetProjectDependencyGraph().GetTopologicallySortedProjects())
            {
                Project project = solution.GetProject(projectId);
                if (project == null)
                {
                    continue;
                }

                IQActionsQAction qaction = solutionModel.GetQAction(projectId);
                if (qaction == null)
                {
                    continue;
                }

                CompileQAction(projectsData, projectId, project, qaction);
            }
        }

        private void CompileQAction(Dictionary<ProjectId, CompiledQActionProject> projectsData, ProjectId projectId, Project project, IQActionsQAction qaction)
        {
            // Build the project.
            var buildResult = BuildProject(project);

            CompiledQActionProject projectData = new CompiledQActionProject(projectId, qaction, project)
            {
                BuildSucceeded = buildResult.Result,
                CompilationErrors = buildResult.CompilationErrors
            };

            var compilation = buildResult.Compilation;
            if (compilation != null)
            {
                string projectFolderPath = null;
                if (IsSolutionBased)
                {
                    FileInfo projectFileInfo = new FileInfo(project.FilePath);
                    DirectoryInfo projectDirectoryInfo = projectFileInfo.Directory;
                    projectFolderPath = projectDirectoryInfo.FullName;
                }

                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    if (IsSolutionBased
                        && (syntaxTree.FilePath.StartsWith(projectFolderPath + "\\bin\\")
                            || syntaxTree.FilePath.StartsWith(projectFolderPath + "\\obj\\")
                            || syntaxTree.FilePath.StartsWith(projectFolderPath + "\\Properties\\")))
                    {
                        continue;
                    }

                    var semanticModel = compilation.GetSemanticModel(syntaxTree, true);
                    projectData.AddSyntaxTreeAndModelPair(syntaxTree, semanticModel);
                }
            }

            projectsData.Add(projectId, projectData);
        }

        private static CompilationResult BuildProject(Project project)
        {
            CompilationResult buildResult = new CompilationResult { AssemblyName = project.Name };

            var lastTask = project.GetCompilationAsync().ContinueWith(compileTask =>
            {
                var compilation = compileTask.Result;
                var diagnostics = compilation.GetDiagnostics();

                List<Diagnostic> compilationErrors = new List<Diagnostic>();
                foreach (var diagnostic in diagnostics)
                {
                    if (diagnostic.Severity == DiagnosticSeverity.Error)
                    {
                        compilationErrors.Add(diagnostic);
                    }
                }

                buildResult.CompilationErrors = compilationErrors;
                buildResult.Result = compilationErrors.Count == 0;
                buildResult.Compilation = compilation;
            });

            lastTask.Wait();

            return buildResult;
        }

        private void CreateDefaultDllReferences(DotNetFrameworkVersion dotNetVersion)
        {
            defaultReferences = new List<MetadataReference>();

            foreach (var assemblyRef in DefaultReferencedAssemblies)
            {
                string assemblyRefFullPath = assemblyRef;

                if (dllImportResolver != null)
                {
                    assemblyRefFullPath = dllImportResolver.TryResolve(assemblyRef);
                }

                if (dotNetVersion.IsDotNetFrameworkAssemblyFile(assemblyRef))
                {
                    assemblyRefFullPath = $"{dotNetVersion.AssembliesPath}{assemblyRef}";
                }

                if (File.Exists(assemblyRefFullPath))
                {
                    defaultReferences.Add(MetadataReferenceCache.CreateFromFile(assemblyRefFullPath));
                }
            }
        }

        private void AddDllImportReferences(AdhocWorkspace workspace, Dictionary<int, (ProjectId projectId, IQActionsQAction qa)> allProjects, ProjectId helperProject, DotNetFrameworkVersion dotNetFrameworkVersion, Dictionary<ProjectId, CompiledQActionProject> projectsData)
        {
            var solution = workspace.CurrentSolution;

            foreach (var currentProject in allProjects)
            {
                // Holds all project references.
                List<ProjectReference> projectReferencesToAdd = new List<ProjectReference>();

                // Holds all additional DLL references.
                List<MetadataReference> additionalDllReferencesToAdd = new List<MetadataReference>();

                // Add a reference to the QAction helper to all QActions.
                if (helperProject != null)
                {
                    ProjectReference helperClassProjectReference = new ProjectReference(helperProject);
                    projectReferencesToAdd.Add(helperClassProjectReference);
                }

                // Process the dllImport attribute of the QAction to verify if we need to add additional project and/or DLL references.
                var quickAction = currentProject.Value.qa;
                string dllImportAttributeValue = quickAction?.DllImport?.Value;

                if (!String.IsNullOrWhiteSpace(dllImportAttributeValue))
                {
                    IEnumerable<string> imports = dllImportAttributeValue.Split(';').Distinct();

                    foreach (var import in imports)
                    {
                        try
                        {
                            if (String.IsNullOrWhiteSpace(import) || import.EndsWith("\\") || import.EndsWith("/") || DefaultReferencedAssemblies.Contains(import))
                            {
                                continue;
                            }

                            ProcessDllImport(allProjects, dllImportResolver, dotNetFrameworkVersion, projectReferencesToAdd, additionalDllReferencesToAdd, import);
                        }
                        catch (FileNotFoundException)
                        {
                            DiagnosticDescriptor descriptor = new DiagnosticDescriptor("1", "Reference Not Found", "Could not find DLL: " + import, "Error", DiagnosticSeverity.Error, true);
                            Diagnostic diagnostic = Diagnostic.Create(descriptor, null);

                            Project project = solution.GetProject(currentProject.Value.projectId);
                            CompiledQActionProject projectData = new CompiledQActionProject(currentProject.Value.projectId, currentProject.Value.qa, project)
                            {
                                BuildSucceeded = false,
                                CompilationErrors = new List<Diagnostic> { diagnostic }
                            };

                            projectsData.Add(currentProject.Value.projectId, projectData);

                            solutionCreationFailed = true;
                            break;
                        }
                    }
                }

                if (projectReferencesToAdd.Count > 0)
                {
                    var referencesToAdd = new List<ProjectReference>();

                    foreach (var projectReferenceToAdd in projectReferencesToAdd)
                    {
                        if (projectReferenceToAdd.ProjectId.Id == currentProject.Value.projectId.Id)
                        {
                            continue;
                        }

                        var projectDependencyGraph = solution.GetProjectDependencyGraph();

                        var projectsReferencingThisProject = projectDependencyGraph.GetProjectsThatTransitivelyDependOnThisProject(currentProject.Value.projectId);

                        var circularReferencedProjects = projectsReferencingThisProject.Where(p => p.Id == projectReferenceToAdd.ProjectId.Id).ToList();

                        if (circularReferencedProjects.Count == 0)
                        {
                            referencesToAdd.Add(projectReferenceToAdd);
                        }
                    }

                    if (referencesToAdd.Count > 0)
                    {
                        var currentProj = solution.GetProject(currentProject.Value.projectId);
                        var modifiedProject = currentProj.AddProjectReferences(referencesToAdd);
                        solution = modifiedProject.Solution;
                    }
                }

                if (additionalDllReferencesToAdd.Count > 0)
                {
                    var currentProj = solution.GetProject(currentProject.Value.projectId);
                    var modifiedProject = currentProj.AddMetadataReferences(additionalDllReferencesToAdd);
                    solution = modifiedProject.Solution;
                }
            }

            bool changesSucceeded = workspace.TryApplyChanges(solution);
            if (!changesSucceeded)
            {
                Debug.Write("Adding references failed");
            }
        }

        private static void ProcessDllImport(Dictionary<int, (ProjectId projectId, IQActionsQAction qa)> allProjects, IAssemblyResolver dllImportResolver, DotNetFrameworkVersion dotNetFrameworkVersion, List<ProjectReference> projectReferencesToAdd, List<MetadataReference> additionalDllReferencesToAdd, string import)
        {
            Match m = QActionRegex.Match(import);

            // [ProtocolName].[ProtocolVersion].QAction.63000.dll
            if (m.Success)
            {
                int qActionId = Convert.ToInt32(m.Groups["id"].Value);

                if (allProjects.TryGetValue(qActionId, out (ProjectId project, IQActionsQAction qa) referencedProject))
                {
                    ProjectReference projectReference = new ProjectReference(referencedProject.project);
                    projectReferencesToAdd.Add(projectReference);
                }
            }
            else
            {
                if (dotNetFrameworkVersion.IsDotNetFrameworkAssemblyFile(import))
                {
                    additionalDllReferencesToAdd.Add(MetadataReferenceCache.CreateFromFile($"{dotNetFrameworkVersion.AssembliesPath}{import}"));
                }
                else
                {
                    // This is a custom DLL that is referenced.
                    if (dllImportResolver != null)
                    {
                        bool couldBeResolved = dllImportResolver.TryResolve(import, out string resolvedImport);

                        if (couldBeResolved)
                        {
                            additionalDllReferencesToAdd.Add(MetadataReferenceCache.CreateFromFile(resolvedImport));
                        }
                    }
                }

                Debug.Write(import + ",");
            }
        }

        private static ProjectId AddProject(AdhocWorkspace workspace, VersionStamp versionStamp, string projectName, LanguageVersion languageVersion, ICollection<MetadataReference> defaultReferences)
        {
            ProjectId projectId = ProjectId.CreateNewId();

            CSharpParseOptions parseOptions = new CSharpParseOptions(languageVersion)
                .WithPreprocessorSymbols(Preprocessors);

            CompilationOptions compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

            ProjectInfo projectInfo = ProjectInfo.Create(projectId, versionStamp, projectName, projectName, LanguageNames.CSharp)
                .WithCompilationOptions(compilationOptions)
                .WithParseOptions(parseOptions)
                .WithMetadataReferences(defaultReferences);

            Solution solution;
            do
            {
                solution = workspace.CurrentSolution;
                solution = solution.AddProject(projectInfo);
            }
            while (!workspace.TryApplyChanges(solution));

            return projectId;
        }

        private static Dictionary<int, (ProjectId project, IQActionsQAction qa)> AddProjectsToWorkSpace(IEnumerable<IQActionsQAction> qActions, AdhocWorkspace workspace, VersionStamp versionStamp, ICollection<MetadataReference> defaultReferences, LanguageVersion languageVersion)
        {
            Dictionary<int, (ProjectId project, IQActionsQAction qa)> allProjects = new Dictionary<int, (ProjectId project, IQActionsQAction qa)>();

            foreach (var qAction in qActions)
            {
                if (String.IsNullOrEmpty(qAction.Code))
                {
                    continue;
                }

                uint? nullableQaId = qAction.Id?.Value;

                if (nullableQaId == null)
                {
                    continue;
                }

                if(qAction.Encoding?.Value != Enums.EnumQActionEncoding.Csharp)
                {
                    continue;
                }

                int qaId = (int)nullableQaId;
                string projectName = $"QAction_{qaId}";
                string fileName = $"{projectName}.cs";
                var sourceText = new QActionSourceText(qAction);

                ProjectId newProject = AddProject(workspace, versionStamp, projectName, languageVersion, defaultReferences);
                workspace.AddDocument(newProject, fileName, sourceText);

                if (!allProjects.ContainsKey(qaId))
                {
                    allProjects.Add(qaId, (newProject, qAction));
                }
            }

            return allProjects;
        }
    }
}
