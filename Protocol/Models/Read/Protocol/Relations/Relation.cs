using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{

    internal partial class RelationsRelation : IRelationEvaluator
    {
        #region Get

        #endregion

        #region IRelationManager

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var p = Path?.Value;
            if (!String.IsNullOrWhiteSpace(p))
            {
                foreach (var pid in p.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    yield return new Reference(this, Mappings.ParamsById, pid, this, isLogic: false);
            }
        }

        #endregion

    }
}
