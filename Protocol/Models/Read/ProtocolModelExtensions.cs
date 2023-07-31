namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;

    public static class ProtocolModelExtensions
    {
        #region Each
        
        public static IEnumerable<IParameterGroupsGroup> EachParameterGroupWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.ParameterGroups, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IParamsParam> EachParamWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Params, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IQActionsQAction> EachQActionWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.QActions, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IHTTPSession> EachHttpSessionWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.HTTP, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IHTTPSessionConnection> EachHttpConnectionWithValidId(this IProtocolModel protocolModel, IHTTPSession httpSession)
        {
            return EachItemWithValidId(httpSession, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<ICommandsCommand> EachCommandWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Commands, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IResponsesResponse> EachResponseWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Responses, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IPairsPair> EachPairWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Pairs, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IGroupsGroup> EachGroupWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Groups, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<ITriggersTrigger> EachTriggerWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Triggers, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<IActionsAction> EachActionWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Actions, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<ITimersTimer> EachTimerWithValidId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.Timers, item => Convert.ToString(item?.Id?.Value));
        }

        public static IEnumerable<ITreeControlsTreeControl> EachTreeControlWithValidParameterId(this IProtocolModel protocolModel)
        {
            return EachItemWithValidId(protocolModel?.Protocol?.TreeControls, item => Convert.ToString(item?.ParameterId?.Value));
        }

        private static IEnumerable<T> EachItemWithValidId<T>(IReadableList<T> items, Func<T, string> getId) where T : IReadable
        {
            if (items == null)
            {
                yield break;
            }

            foreach (T item in items)
            {
                string id = getId(item);
                if (String.IsNullOrWhiteSpace(id))
                {
                    // We won't check items that don't have an id attribute.
                    continue;
                }

                yield return item;
            }
        }

        #endregion
    }
}