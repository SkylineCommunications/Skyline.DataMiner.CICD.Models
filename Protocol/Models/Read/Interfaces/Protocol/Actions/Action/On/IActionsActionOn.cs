namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    public partial interface IActionsActionOn
    {
        IReadOnlyList<uint> GetId();
    }
}