namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Linq;

    internal partial class VersionHistory
    {
        public bool TryGetBranch(string branchNbr, out IVersionHistoryBranchesBranch branch)
        {
            branch = null;

            if (Branches == null)
            {
                return false;
            }

            branch = Branches.FirstOrDefault(b => b.Id?.RawValue == branchNbr);
            return branch != null;
        }

        public bool TryGetSystemVersion((string branchNbr, string systemNbr) version, out IVersionHistoryBranchesBranchSystemVersionsSystemVersion systemVersion)
        {
            systemVersion = null;

            if (!TryGetBranch(version.branchNbr, out var branch) || branch.SystemVersions == null)
            {
                return false;
            }

            systemVersion = branch.SystemVersions.FirstOrDefault(system => system.Id?.RawValue == version.systemNbr);
            return systemVersion != null;
        }

        public bool TryGetMajorVersion((string branchNbr, string systemNbr, string majorNbr) version,
            out IVersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersion majorVersion)
        {
            majorVersion = null;
            
            if (!TryGetSystemVersion((version.branchNbr, version.systemNbr), out var system) || system.MajorVersions == null)
            {
                return false;
            }
            
            majorVersion = system.MajorVersions.FirstOrDefault(major => major.Id?.RawValue == version.majorNbr);
            return majorVersion != null;
        }

        public bool TryGetMinorVersion((string branchNbr, string systemNbr, string majorNbr, string minorNbr) version,
            out IVersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersionMinorVersionsMinorVersion minorVersion)
        {
            minorVersion = null;
            
            if (!TryGetMajorVersion((version.branchNbr, version.systemNbr, version.majorNbr), out var major) || major.MinorVersions == null)
            {
                return false;
            }
            
            minorVersion = major.MinorVersions.FirstOrDefault(minor => minor.Id?.RawValue == version.minorNbr);
            return minorVersion != null;
        }

        public bool TryGetMinorVersion(string version,
            out IVersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersionMinorVersionsMinorVersion minorVersion)
        {
            if (String.IsNullOrWhiteSpace(version))
            {
                minorVersion = null;
                return false;
            }

            var v = GetVersion(version);

            return TryGetMinorVersion(v, out minorVersion);
        }
        
        private static (string branch, string system, string major, string minor) GetVersion(string version)
        {
            string[] v = version?.Split('.');

            if (v?.Length == 4)
            {
                return (v[0], v[1], v[2], v[3]);
            }

            return (null, null, null, null);
        }
    }
}