using System.Collections.Generic;

namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Linking
{
    internal interface IRelationEvaluator
    {
        IEnumerable<Reference> GetRelations();
    }
}
