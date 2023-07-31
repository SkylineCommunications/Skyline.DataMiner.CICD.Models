namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;

    public partial interface ITreeControlsTreeControl
    {
        /// <summary>
        /// Get all tables displayed within the treeControl (Hierarchy, ExtraTabs, ExtraDetails...).
        /// </summary>
        ICollection<uint> GetDisplayedTablesPids(IProtocolModel model);

        /// <summary>
        /// Retrieves a value indicating whether the parameter that displays this treecontrol exists in the model.
        /// </summary>
        /// <returns><c>true</c> if the parameter that displays this tree control existis in the model; otherwise, <c>false</c>.</returns>
        bool MainParameterExists(IProtocolModel model);
    }
}