namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    internal partial class CommandsCommand : IRelationEvaluator, ICommandsCommand
    {
        #region Get

        public IEnumerable<IParamsParam> GetParameters(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Source == this && link.Target is IParamsParam param)
                {
                    yield return param;
                }
            }
        }

        #endregion

        #region IRelationEvaluator

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var c = Content;
            if (c != null)
            {
                foreach (ICommandsCommandContentParam x in c)
                {
                    yield return new Reference(this, Mappings.ParamsById, Convert.ToString(x.Value), x, isLogic: false);
                }
            }
        }

        #endregion
    }
}