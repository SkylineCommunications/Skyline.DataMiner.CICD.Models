namespace Skyline.DataMiner.CICD.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Assembly resolver that tries to resolve the specified assembly in one of the specified directories.
    /// </summary>
    public class InternalFilesAssemblyResolver : IAssemblyResolver
    {
        private readonly IEnumerable<string> _searchDirs;

        private readonly static DotNetFrameworkVersion dotnetFrameworkVersion = DotNetFrameworkVersion.LatestVersionFromRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalFilesAssemblyResolver"/> class using the specified search directories.
        /// </summary>
        /// <param name="directories">Directories in which to search.</param>
        /// <exception cref="ArgumentNullException"><paramref name="directories"/> is <see langword="null"/>.</exception>
        public InternalFilesAssemblyResolver(IEnumerable<string> directories)
        {
            _searchDirs = directories ?? throw new ArgumentNullException(nameof(directories));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalFilesAssemblyResolver"/> class using the specified search directory.
        /// </summary>
        /// <param name="directory">Directory in which to search.</param>
        /// <exception cref="ArgumentNullException"><paramref name="directory"/> is <see langword="null"/>.</exception>
        public InternalFilesAssemblyResolver(string directory) : this(new[] { directory }) { }

        /// <summary>
        /// Gets the installation path of the .NET Framework.
        /// </summary>
        /// <value>The installation path of the .NET Framework.</value>
        public static string DotNetFrameworkAssemblyPath
        {
            get
            {
                return dotnetFrameworkVersion?.AssembliesPath;
            }
        }
    
        /// <inheritdoc/>
        public string TryResolve(string assembly)
        {
            if (TryResolve(assembly, out string resolved))
                return resolved;

            return assembly;
        }

        /// <inheritdoc/>
        public bool TryResolve(string assembly, out string resolved)
        {
            var info = TryFindDllFile(assembly);
            if (info != null)
            {
                resolved = info.FullName;
                return true;
            }

            resolved = null;
            return false;
        }

        private FileInfo TryFindDllFile(string assembly)
        {
            try
            {
                if (Path.IsPathRooted(assembly) && TryGetFileInfo(assembly, out FileInfo info))
                {
                    return info;
                }

                string filename;
                foreach (var dir in _searchDirs)
                {
                    filename = Path.Combine(dir, assembly);
                    if (File.Exists(filename) && TryGetFileInfo(filename, out info))
                    {
                        return info;
                    }
                }

                if(DotNetFrameworkAssemblyPath != null)
                {
                    filename = Path.Combine(DotNetFrameworkAssemblyPath, assembly);
                    if (TryGetFileInfo(filename, out info))
                    {
                        return info;
                    }
                }
            }
            catch
            {
                // Ignore all
            }

            return null;
        }

        private static bool TryGetFileInfo(string filename, out FileInfo info)
        {
            info = null;
            try
            {
                info = new FileInfo(filename);
                if (info.Exists)
                {
                    info.Refresh();
                    return true;
                }
            }
            catch { /* ignore all */ }
            return false;
        }
    }
}
