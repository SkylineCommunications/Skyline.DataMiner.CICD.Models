namespace Skyline.DataMiner.CICD.Models.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Win32;

    /// <summary>
    /// Helper for retrieving the .NET Framework versions available on the system.
    /// </summary>
    public class DotNetFrameworkVersion
    {
        private const string DotNetAssembliesBasePath = "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\";
        private const string RegistrySubKey = "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\";

        private static readonly object _latestVersionLock = new object();
        private static readonly object _listLock = new object();
        private static List<DotNetFrameworkVersion> _availableVersions;
        private static DotNetFrameworkVersion _latestVersionFromRegistry;
        private IEnumerable<FileInfo> _dotNetFrameworkAssemblies;

        private DotNetFrameworkVersion(string specificAssemblyPathFolder, string dotNetVersion, bool fromRegistry)
        {
            AssembliesPath = specificAssemblyPathFolder ?? throw new ArgumentNullException(nameof(specificAssemblyPathFolder));
            Version = dotNetVersion ?? throw new ArgumentNullException(nameof(dotNetVersion));
            FromRegistry = fromRegistry;

            var dirInfo = new DirectoryInfo(specificAssemblyPathFolder);
            if (!dirInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Unable to find assemblies directory: {specificAssemblyPathFolder}");
            }
        }

        /// <summary>
        /// Gets the latest version of the .NET Framework that is installed according to the Registry.
        /// </summary>
        /// <value>The latest version of the .NET Framework that is installed according to the Registry.</value>
        public static DotNetFrameworkVersion LatestVersionFromRegistry
        {
            get
            {
                lock (_latestVersionLock)
                {
                    if (_latestVersionFromRegistry == null)
                    {
                        _latestVersionFromRegistry = GetLatestDotNetFrameworkVersionFromRegistry();
                    }
                }

                return _latestVersionFromRegistry;
            }
        }

        /// <summary>
        /// Gets the installation path of the .NET Framework assemblies.
        /// </summary>
        /// <value>The installation path of the .NET Framework assemblies.</value>
        public string AssembliesPath { get; }

        /// <summary>
        /// Gets the available versions of the .NET Framework on the system.
        /// </summary>
        /// <value>The available versions of the .NET Framework on the system.</value>
        /// <exception cref="InvalidOperationException">Unable to find registry key for latest .NET Framework directory.</exception>
        public static IEnumerable<DotNetFrameworkVersion> AvailableVersions
        {
            get
            {
                lock (_listLock)
                {
                    if (_availableVersions == null)
                    {
                        _availableVersions = FindAvailableDotNetFrameworkVersions().ToList();
                    }
                }

                return _availableVersions;
            }
        }

        /// <summary>
        /// Gets the installation path ofr the .NET Framework.
        /// </summary>
        /// <value>The installation path ofr the .NET Framework.</value>
        /// <exception cref="DirectoryNotFoundException">The assembly directory does not exist.</exception>
        public IEnumerable<FileInfo> DotNetFrameworkAssemblies
        {
            get
            {
                var dirInfo = new DirectoryInfo(AssembliesPath);
                if (_dotNetFrameworkAssemblies == null)
                {
                    _dotNetFrameworkAssemblies = dirInfo.EnumerateFiles("*.dll", SearchOption.TopDirectoryOnly);
                }

                return _dotNetFrameworkAssemblies;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this version was obtained via the registry.
        /// </summary>
        /// <c>true</c> if this version was obtained via the registry; otherwise, <c>false</c>.
        public bool FromRegistry { get; }

        /// <summary>
        /// Gets the version string.
        /// </summary>
        /// <value>The version string.</value>
        public string Version { get; }

        /// <summary>
        /// Retrieves the latest installed version of the .NET Framework from the registry.
        /// </summary>
        /// <returns>The latest installed version of the .NET Framework from the registry or <see langword="null"/> if not found.</returns>
        private static DotNetFrameworkVersion GetLatestDotNetFrameworkVersionFromRegistry()
        {
            RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(RegistrySubKey);
            if (ndpKey == null)
            {
                return null;
            }

            var installPath = ndpKey.GetValue("InstallPath");
            if (installPath == null)
            {
                ndpKey.Dispose();
                return null;
            }

            var version = ndpKey.GetValue("Version");
            if (version == null)
            {
                ndpKey.Dispose();
                return null;
            }

            ndpKey.Dispose();
            return new DotNetFrameworkVersion((string)installPath, (string)version, true);
        }

        /// <summary>
        /// Returns a value indicating whether the specified assembly is part of the .NET Framework.
        /// </summary>
        /// <param name="filename">The assembly file name.</param>
        /// <returns><c>true</c> if the specified assembly is part of the .NET Framework; otherwise, <c>false</c>.</returns>
        public bool IsDotNetFrameworkAssemblyFile(string filename)
        {
            foreach (var fi in DotNetFrameworkAssemblies)
            {
                if (fi.Name.Equals(filename, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Version;
        }

        private static IEnumerable<DotNetFrameworkVersion> FindAvailableDotNetFrameworkVersions()
        {
            List<DotNetFrameworkVersion> result = new List<DotNetFrameworkVersion>();
            var dirInfo = new DirectoryInfo(DotNetAssembliesBasePath);
            if (dirInfo.Exists)
            {
                var dotNetFrameworkDirs = dirInfo.EnumerateDirectories();

                foreach (var dir in dotNetFrameworkDirs)
                {
                    // Folders without System.dll in it are definitely not valid.
                    if (dir.EnumerateFiles("System.dll", SearchOption.TopDirectoryOnly).GetEnumerator().Current != null)
                    {
                        continue;
                    }

                    var assembliesPath = dir.FullName + "\\";
                    var versionSplit = dir.FullName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    var version = versionSplit[versionSplit.GetUpperBound(0)];
                    var dotNetVersion = new DotNetFrameworkVersion(assembliesPath, version, false);
                    result.Add(dotNetVersion);
                }
            }

            var latestFromReg = GetLatestDotNetFrameworkVersionFromRegistry();
            if (latestFromReg == null)
            {
                throw new InvalidOperationException("Unable to find registry key for latest .NET Framework directory. Check your .NET Framework installation.");
            }

            result.Add(latestFromReg);

            return result;
        }
    }
}
