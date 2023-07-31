namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public partial interface IVersionHistory
    {
        bool TryGetBranch(string branchNbr, out IVersionHistoryBranchesBranch branch);

        bool TryGetSystemVersion((string branchNbr, string systemNbr) version, out IVersionHistoryBranchesBranchSystemVersionsSystemVersion systemVersion);

        bool TryGetMajorVersion((string branchNbr, string systemNbr, string majorNbr) version,
            out IVersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersion majorVersion);

        bool TryGetMinorVersion((string branchNbr, string systemNbr, string majorNbr, string minorNbr) version,
            out IVersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersionMinorVersionsMinorVersion minorVersion);

        bool TryGetMinorVersion(string version,
            out IVersionHistoryBranchesBranchSystemVersionsSystemVersionMajorVersionsMajorVersionMinorVersionsMinorVersion minorVersion);
    }
}