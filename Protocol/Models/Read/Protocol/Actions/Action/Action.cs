namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Skyline.DataMiner.CICD.Models.Protocol.Enums;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    internal partial class ActionsAction : IRelationEvaluator, IActionsAction
    {
        #region Get

        public IEnumerable<IGroupsGroup> GetGroups(RelationManager relationManager)
        {
            return relationManager.GetForwardLinks(this)
                .Where(l => l.Source == this && l.Target is IGroupsGroup)
                .Select(l => (IGroupsGroup)l.Target);
        }

        public IEnumerable<ITriggersTrigger> GetTriggeringTriggers(RelationManager relationManager)
        {
            return relationManager.GetReverseLinks(this)
                .Where(l => l.Target == this && l.Source is ITriggersTrigger)
                .Select(l => (ITriggersTrigger)l.Source);
        }

        #endregion

        #region IRelationManager

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var o = On;
            if (o?.Id != null)
            {
                string ref_ids = Convert.ToString(o.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_ids))
                {
                    foreach (var ref_id in ref_ids.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        switch (o.Value)
                        {
                            case EnumActionOn.Parameter:
                                yield return new Reference(this, Mappings.ParamsById, ref_id, o);
                                break;
                            case EnumActionOn.Group:
                                yield return new Reference(this, Mappings.GroupsById, ref_id, o);
                                break;
                            case EnumActionOn.Pair:
                                yield return new Reference(this, Mappings.PairsById, ref_id, o);
                                break;
                            case EnumActionOn.Command:
                                yield return new Reference(this, Mappings.CommandsById, ref_id, o);
                                break;
                            case EnumActionOn.Response:
                                yield return new Reference(this, Mappings.ResponsesById, ref_id, o);
                                break;
                            case EnumActionOn.Timer:
                                yield return new Reference(this, Mappings.TimersById, ref_id, o);
                                break;
                        }
                    }
                }
            }

            if(o?.Value != null)
            {
                switch (o.Value)
                {
                    case EnumActionOn.Parameter:
                        foreach (var reference in ProcessParameterActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Protocol:
                        foreach (var reference in ProcessProtocolActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Pair:
                        foreach (var reference in ProcessPairActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Command:
                        foreach (var reference in ProcessCommandActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                    case EnumActionOn.Response:
                        foreach (var reference in ProcessResponseActionReferences())
                        {
                            yield return reference;
                        }
                        break;
                }
            }

            var condition = Condition;
            if (condition?.Value != null)
            {
                foreach (Match m in Regex.Matches(condition.Value, @"id:(?<id>\d+)"))
                {
                    string ref_id = m.Groups["id"].Value;
                    yield return new Reference(this, Mappings.ParamsById, ref_id, condition, "Conditions", "Conditions", isLogic: false);
                }
            }
        }

        private IEnumerable<Reference> ProcessParameterActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Append:
                        case EnumActionType.AppendData:
                        case EnumActionType.ChangeLength:
                        case EnumActionType.Copy:
                        case EnumActionType.CopyReverse:
                        case EnumActionType.Normalize:
                        case EnumActionType.SetAndGetWithWait:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }

                var optionsValue = Convert.ToString(t.Options?.Value);
                if (!String.IsNullOrWhiteSpace(optionsValue))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Aggregate:
                            string[] options = optionsValue.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var option in options)
                            {
                                if (option.StartsWith("defaultValue:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var defaultValue = option.Substring(12);
                                    string[] defaultValueParts = defaultValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                    if (defaultValueParts.Length > 1 && Int32.TryParse(defaultValueParts[0], out int defaultValueColumnPid))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, defaultValueColumnPid.ToString(), t, reverse: true, isLogic: false);
                                    }
                                }
                                else if (option.StartsWith("equation:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var equationValue = option.Substring(8);
                                    string[] equationValueParts = equationValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                    if (equationValueParts.Length > 1 && Int32.TryParse(equationValueParts[1], out int columnPid))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                    }
                                }
                                else if (option.StartsWith("equationvalue:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var equationValue = option.Substring(13);
                                    string[] equationValueParts = equationValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                    if (equationValueParts.Length > 2 && Int32.TryParse(equationValueParts[2], out int columnPid))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                    }
                                }
                                else if(option.StartsWith("groupby:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var groupByValue = option.Substring(7);
                                    string[] groupByValueParts = groupByValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                    foreach(var groupByPart in groupByValueParts)
                                    {
                                        string[] groupByEntryParts = groupByPart.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                                        if (groupByEntryParts.Length > 1 && Int32.TryParse(groupByEntryParts[1], out int groupByParamId))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, groupByParamId.ToString(), t, reverse: true, isLogic: false);
                                        }
                                    }
                                }
                                else if (option.StartsWith("groupbytable:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var groupByTableValue = option.Substring(13);

                                    if (Int32.TryParse(groupByTableValue, out int groupByTableParamId))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, groupByTableParamId.ToString(), t, reverse: true, isLogic: false);
                                    }
                                }
                                else if (option.StartsWith("join:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var joinValue = option.Substring(5);
                                    string[] joinValueParts = joinValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    foreach (var joinPart in joinValueParts)
                                    {
                                        if (Int32.TryParse(joinPart, out int joinParamId))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, joinPart, t, reverse: true, isLogic: false);
                                        }
                                    }
                                }
                                else if (option.StartsWith("return:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var returnValue = option.Substring(7);
                                    string[] returnValueParts = returnValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    foreach (var returnValuePart in returnValueParts)
                                    {
                                        if (Int32.TryParse(returnValuePart, out int returnParamId))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, returnValuePart, t, reverse: true, isLogic: false);
                                        }
                                    }
                                }
                                else if (option.StartsWith("status:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var statusValue = option.Substring(7);

                                    if (Int32.TryParse(statusValue, out int columnPid))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                    }
                                }
                                else if (option.StartsWith("weight:", StringComparison.OrdinalIgnoreCase))
                                {
                                    var weightValue = option.Substring(7);

                                    if (Int32.TryParse(weightValue, out int columnPid))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, columnPid.ToString(), t, reverse: true, isLogic: false);
                                    }
                                }
                            }
                           break;
                    }
                }
            }
        }

        private IEnumerable<Reference> ProcessProtocolActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Close:
                        case EnumActionType.ReadFile:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }

            if (t?.Nr != null)
            {
                string nrValue_id = Convert.ToString(t.Nr?.Value);
                if (!String.IsNullOrWhiteSpace(nrValue_id) && Int32.TryParse(nrValue_id, out _))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.ReadFile:
                            yield return new Reference(this, Mappings.ParamsById, nrValue_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }

            if (t?.ReturnValue != null)
            {
                string returnValue_id = Convert.ToString(t.ReturnValue?.Value);
                if (!String.IsNullOrWhiteSpace(returnValue_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.ReadFile:
                            if(Int32.TryParse(returnValue_id, out _))
                            {
                                yield return new Reference(this, Mappings.ParamsById, returnValue_id, t, reverse: true, isLogic: false);
                            }
                            break;
                        case EnumActionType.Wmi:
                            {
                                string[] parts = returnValue_id.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                                for (int i = 0; i < parts.Length; i++)
                                {
                                    string paramId = parts[i];
                                    if (!String.IsNullOrWhiteSpace(paramId) && Int32.TryParse(paramId, out _))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, paramId, t, reverse: true, isLogic: false);
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            if (t?.Startoffset != null)
            {
                string startOffsetValue_id = Convert.ToString(t.Startoffset?.Value);
                if (!String.IsNullOrWhiteSpace(startOffsetValue_id) && Int32.TryParse(startOffsetValue_id, out _))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.ReadFile:
                            yield return new Reference(this, Mappings.ParamsById, startOffsetValue_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }

            if (t?.Options != null)
            {
                string optionsValue = Convert.ToString(t.Options?.Value);

                if (!String.IsNullOrEmpty(optionsValue))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Merge:
                            {
                                string[] options = optionsValue.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var option in options)
                                {
                                    if (option.StartsWith("destination:", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var destinations = option.Substring(12).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                        foreach(var destination in destinations)
                                        {
                                            if (Int32.TryParse(destination, out _))
                                            {
                                                yield return new Reference(this, Mappings.ParamsById, destination, t, reverse: true, isLogic: false);
                                            }
                                        }
                                    }
                                    else if (option.StartsWith("defaultValue:", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var defaultValue = option.Substring(13);
                                        int commaIndex = defaultValue.IndexOf(',');

                                        if (commaIndex > -1 && Int32.TryParse(defaultValue.Substring(0, commaIndex), out int defaultValueColumnPid))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, defaultValueColumnPid.ToString(), t, reverse: true, isLogic: false);
                                        }
                                    }
                                    else if (option.StartsWith("destinationfindpk:", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var destinations = option.Substring(18).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                        foreach (var destination in destinations)
                                        {
                                            if (Int32.TryParse(destination, out _))
                                            {
                                                yield return new Reference(this, Mappings.ParamsById, destination, t, reverse: true, isLogic: false);
                                            }
                                        }
                                    }
                                    else if (option.StartsWith("limitresult:", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var limitResultValue = option.Substring(12);

                                        if (Int32.TryParse(limitResultValue, out _))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, limitResultValue, t, reverse: true, isLogic: false);
                                        }
                                    }
                                    else if (option.StartsWith("remoteElements:", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var remoteElementsValue = option.Substring(15);

                                        if (Int32.TryParse(remoteElementsValue, out _))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, remoteElementsValue, t, reverse: true, isLogic: false);
                                        }
                                    }
                                    else if (option.StartsWith("resolve:", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var resolveValue = option.Substring(8).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                        foreach (var resolvePid in resolveValue)
                                        {
                                            if (Int32.TryParse(resolvePid, out _))
                                            {
                                                yield return new Reference(this, Mappings.ParamsById, resolvePid, t, reverse: true, isLogic: false);
                                            }
                                        }
                                    }
                                    else if (option.StartsWith("trigger:", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var triggerValue = option.Substring(8);

                                        if (Int32.TryParse(triggerValue, out _))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, triggerValue, t, reverse: true, isLogic: false);
                                        }
                                    }
                                }
                            }
                            break;
                        case EnumActionType.SwapColumn:
                            {
                                string[] parts = optionsValue.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                if(parts.Length > 1)
                                {
                                    for(int i=1; i < parts.Length; i++)
                                    {
                                        string paramId = parts[i];
                                        if (!String.IsNullOrWhiteSpace(paramId) && Int32.TryParse(paramId, out _))
                                        {
                                            yield return new Reference(this, Mappings.ParamsById, paramId, t, reverse: true, isLogic: false);
                                        }
                                    }
                                }
                            }
                            break;
                        case EnumActionType.Wmi:
                            {
                                string[] options = optionsValue.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach(var option in options)
                                {
                                    if (option.StartsWith("pwd:", StringComparison.OrdinalIgnoreCase) && Int32.TryParse(option.Substring(4), out int pwdParamId))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, pwdParamId.ToString(), t, reverse: true, isLogic: false);
                                    }
                                    else if (option.StartsWith("server:", StringComparison.OrdinalIgnoreCase) && Int32.TryParse(option.Substring(7), out int serverParamId))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, serverParamId.ToString(), t, reverse: true, isLogic: false);
                                    }
                                    else if (option.StartsWith("uname:", StringComparison.OrdinalIgnoreCase) && Int32.TryParse(option.Substring(6), out int userParamId))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, userParamId.ToString(), t, reverse: true, isLogic: false);
                                    }
                                    else if (option.StartsWith("where:ID:", StringComparison.OrdinalIgnoreCase) && Int32.TryParse(option.Substring(9), out int whereClauseParamId))
                                    {
                                        yield return new Reference(this, Mappings.ParamsById, whereClauseParamId.ToString(), t, reverse: true, isLogic: false);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }

        private IEnumerable<Reference> ProcessCommandActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Replace:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }
        }

        private IEnumerable<Reference> ProcessResponseActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.Replace:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }
        }

        private IEnumerable<Reference> ProcessPairActionReferences()
        {
            var t = Type;
            if (t?.Value != null)
            {
                string ref_id = Convert.ToString(t.Id?.Value);
                if (!String.IsNullOrWhiteSpace(ref_id))
                {
                    switch (t.Value.Value)
                    {
                        case EnumActionType.SetNext:
                        case EnumActionType.Timeout:
                            yield return new Reference(this, Mappings.ParamsById, ref_id, t, reverse: true, isLogic: false);
                            break;
                    }
                }
            }
        }
        #endregion
    }
}