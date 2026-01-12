namespace ProtocolTests.Roslyn
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Skyline.DataMiner.CICD.Models.Common;
    using Skyline.DataMiner.CICD.Models.Protocol;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    [TestClass]
    public class QActionCompilationModelTests
    {
        [TestMethod]
        public void FromSolutionUsingStorageTypes()
        {
            // Arrange.
            string xmlString = File.ReadAllText(@"..\..\..\ProtocolExamples\TestProtocolStorageTypes.xml");

            (ProtocolModel model, _) = Generic.ParseProtocol(xmlString);

            string qactionHelperSource = @"using System.ComponentModel;
using System.Collections;
            using System.Collections.Generic;
            using System.Linq;

namespace Skyline.DataMiner.Scripting
    {
        public static class Parameter
        {
            public class Write
            {
            }
        }
        public class SLProtocolExt : SLProtocol
        {
            public WriteParameters Write;
            public class WriteParameters
            {
                public SLProtocolExt Protocol;
                public WriteParameters(SLProtocolExt protocol)
                {
                    Protocol = protocol;
                }
            }
            public SLProtocolExt()
            {
                Write = new WriteParameters(this);
            }
        }
    }";

            string baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IAssemblyResolver dllImportResolver = new InternalFilesAssemblyResolver(baseDir);

            var solutionSemanticModel = new QActionCompilationModel(qactionHelperSource, model, dllImportResolver);

            bool buildSucceeded = true;

            IReadOnlyDictionary<Microsoft.CodeAnalysis.ProjectId, CompiledQActionProject> projectsData = null;

            // Act.
            try
            {
                projectsData = solutionSemanticModel.Build();
            }
            catch (ReflectionTypeLoadException e)
            {
                string message = String.Join("###", e.LoaderExceptions?.Select(x => x.Message));
                Assert.Fail(message);
            }

            // Assert.
            foreach (var projectId in projectsData.Keys)
            {
                var compiledProject = projectsData[projectId];

                // We only validate if the build of the project succeeded.
                if (!compiledProject.BuildSucceeded)
                {
                    buildSucceeded = false;
                    break;
                }
            }

            Assert.IsTrue(buildSucceeded);
        }

        [TestMethod]
        public void FromSolution()
        {
            int detectedViolationCount = 0;
            int expectedViolationCount = 1;

            string xmlString = File.ReadAllText(@"..\..\..\ProtocolExamples\TestProtocol.xml");

            (ProtocolModel model, _) = Generic.ParseProtocol(xmlString);

            string qactionHelperSource = @"using System.ComponentModel;
using System.Collections;
            using System.Collections.Generic;
            using System.Linq;

namespace Skyline.DataMiner.Scripting
    {
        public static class Parameter
        {
            public class Write
            {
            }
        }
        public class SLProtocolExt : SLProtocol
        {
            public WriteParameters Write;
            public class WriteParameters
            {
                public SLProtocolExt Protocol;
                public WriteParameters(SLProtocolExt protocol)
                {
                    Protocol = protocol;
                }
            }
            public SLProtocolExt()
            {
                Write = new WriteParameters(this);
            }
        }
    }";

            string baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IAssemblyResolver dllImportResolver = new InternalFilesAssemblyResolver(baseDir);

            var solutionSemanticModel = new QActionCompilationModel(qactionHelperSource, model, dllImportResolver);
            var projectsData = solutionSemanticModel.Build();

            foreach (var projectId in projectsData.Keys)
            {
                var projectData = projectsData[projectId];

                // We only validate if the build of the project succeeded.
                if (!projectData.BuildSucceeded)
                {
                    continue;
                }

                var treesAndModels = projectData.TreesAndModels;

                foreach (var treeAndModel in treesAndModels)
                {
                    var syntaxTree = treeAndModel.SyntaxTree;
                    var semanticModel = treeAndModel.SemanticModel;

                    if (syntaxTree == null || semanticModel == null)
                    {
                        continue;
                    }

                    InvocationExpressionWalker walker = new InvocationExpressionWalker(model, semanticModel);
                    walker.Visit(syntaxTree.GetRoot());

                    var results = walker.Results;

                    detectedViolationCount = results.Count;
                }
            }

            Assert.AreEqual(expectedViolationCount, detectedViolationCount);
        }

        [TestMethod]
        public void TestProtocolWithDifferentQActionEncodings()
        {
            // Arrange.
            string xmlString = File.ReadAllText(@"..\..\..\ProtocolExamples\TestProtocolQActionTypes.xml");

            (ProtocolModel model, _) = Generic.ParseProtocol(xmlString);

            string qactionHelperSource = @"using System.ComponentModel;
using System.Collections;
            using System.Collections.Generic;
            using System.Linq;

namespace Skyline.DataMiner.Scripting
    {
        public static class Parameter
        {
            public class Write
            {
            }
        }
        public class SLProtocolExt : SLProtocol
        {
            public WriteParameters Write;
            public class WriteParameters
            {
                public SLProtocolExt Protocol;
                public WriteParameters(SLProtocolExt protocol)
                {
                    Protocol = protocol;
                }
            }
            public SLProtocolExt()
            {
                Write = new WriteParameters(this);
            }
        }
    }";

            string baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IAssemblyResolver dllImportResolver = new InternalFilesAssemblyResolver(baseDir);

            var qactionCompilationModel = new QActionCompilationModel(qactionHelperSource, model, dllImportResolver);

            bool buildSucceeded = true;

            IReadOnlyDictionary<Microsoft.CodeAnalysis.ProjectId, CompiledQActionProject> compiledQActionProjects = null;

            // Act.
            try
            {
                compiledQActionProjects = qactionCompilationModel.Build();
            }
            catch (ReflectionTypeLoadException e)
            {
                string message = String.Join("###", e.LoaderExceptions?.Select(x => x.Message));
                Assert.Fail(message);
            }

            Assert.HasCount(5, compiledQActionProjects); // 5 C# QActions

            Assert.IsNull(compiledQActionProjects.FirstOrDefault(q => q.Value.QAction.Id.Value == 10000).Value); // jscript QAction.
            Assert.IsNull(compiledQActionProjects.FirstOrDefault(q => q.Value.QAction.Id.Value == 10001).Value); // vbscript QAction.

            // Assert compilation of C# QActions succeeded.
            foreach (var projectId in compiledQActionProjects.Keys)
            {
                var compiledProject = compiledQActionProjects[projectId];

                // We only validate if the build of the project succeeded.
                if (!compiledProject.BuildSucceeded)
                {
                    buildSucceeded = false;
                    break;
                }
            }

            Assert.IsTrue(buildSucceeded);
        }
    }
}
