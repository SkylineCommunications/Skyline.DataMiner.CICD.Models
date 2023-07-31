namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    using System.Linq;

    public partial class VersionHistory
    {
        public bool TryGetBranch(string branchNbr, out VersionHistoryBranchesBranch branch)
        {
            branch = null;

            if (Branches == null)
            {
                return false;
            }

            branch = Branches.FirstOrDefault(b => b.Id?.RawValue == branchNbr);
            return branch != null;
        }

        public bool TryGetSystemVersion((string branchNbr, string systemNbr) version, out VersionHistoryBranchesBranchSystemVersionsSystemVersion systemVersion)
        {
            systemVersion = null;

            if (!TryGetBranch(version.branchNbr, out var branch) || branch.SystemVersions == null)
            {
                return false;
            }

            systemVersion = branch.SystemVersions.FirstOrDefault(system => system.Id?.RawValue == version.systemNbr);
            return systemVersion != null;
        }

        public bool TryGetMajorVersion((string branchNbr, string systemNbr, string majorNbr) version, out VersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersion majorVersion)
        {
            majorVersion = null;
            
            if (!TryGetSystemVersion((version.branchNbr, version.systemNbr), out var system) || system.MajorVersions == null)
            {
                return false;
            }
            
            majorVersion = system.MajorVersions.FirstOrDefault(major => major.Id?.RawValue == version.majorNbr);
            return majorVersion != null;
        }

        public bool TryGetMinorVersion((string branchNbr, string systemNbr, string majorNbr, string minorNbr) version, out VersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersionMinorVersionsMinorVersion minorVersion)
        {
            minorVersion = null;
            
            if (!TryGetMajorVersion((version.branchNbr, version.systemNbr, version.majorNbr), out var major) || major.MinorVersions == null)
            {
                return false;
            }
            
            minorVersion = major.MinorVersions.FirstOrDefault(minor => minor.Id?.RawValue == version.minorNbr);
            return minorVersion != null;
        }
        
        public bool TryGetMinorVersion(string version, out VersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersionMinorVersionsMinorVersion minorVersion)
        {
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