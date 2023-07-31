namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Skyline.DataMiner.CICD.Parsers.Common.Xml;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
    using Skyline.DataMiner.CICD.Parsers.Protocol.Xml.QActions;

    internal partial class QActionsQAction : IRelationEvaluator, IQActionsQAction
    {
        #region Get

        public IEnumerable<IParamsParam> GetTriggerParameters(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetReverseLinks(this))
            {
                if (link.Source is IParamsParam param)
                {
                    yield return param;
                }
            }
        }

        public IEnumerable<IGroupsGroup> GetTriggerGroups(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetReverseLinks(this))
            {
                if (link.Source is IGroupsGroup group)
                {
                    yield return group;
                }
            }
        }

        public IEnumerable<ITimersTimer> GetTriggerTimers(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetReverseLinks(this))
            {
                if (link.Source is ITimersTimer timer)
                {
                    yield return timer;
                }
            }
        }

        public IReadOnlyList<uint> GetTriggers()
        {
            if (Triggers == null)
            {
                return new List<uint>(0);
            }

            var ids = new List<uint>();
            foreach (var part in Triggers.Value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (UInt32.TryParse(part, out uint id))
                {
                    ids.Add(id);
                }
            }

            return ids;
        }

        public QActionOptions GetOptions()
        {
            if (Options == null)
            {
                return null;
            }

            return new QActionOptions(Options.Value);
        }

        public QActionEntryPoints GetEntryPoints()
        {
            return new QActionEntryPoints(EntryPoint?.Value);
        }

        public IEnumerable<string> GetDllImports()
        {
            string dllImports = DllImport?.Value;
            if (!String.IsNullOrEmpty(dllImports))
            {
                string[] dd = dllImports.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string d in dd)
                {
                    yield return d.Trim();
                }
            }
        }

        public IEnumerable<IQActionsQAction> GetReferencedQActions()
        {
            if (!(Parent is IQActions qactions))
            {
                yield break;
            }

            foreach (string dllImport in GetDllImports())
            {
                var qactionRefMatch = QAction.RegexExtractQActionRef.Match(dllImport);
                if (qactionRefMatch.Success)
                {
                    string dll = qactionRefMatch.Groups["dll"].Value;

                    var qactionIdMatch = QAction.RegexExtractQActionID.Match(dll);
                    if (qactionIdMatch.Success)
                    {
                        var qactionId = Convert.ToInt32(qactionIdMatch.Groups["id"].Value);

                        var qa = qactions.FirstOrDefault(x => x.Id?.Value == qactionId);
                        if (qa != null)
                        {
                            yield return qa;
                        }
                    }
                    else
                    {
                        foreach (var qa in qactions)
                        {
                            var options = qa.GetOptions();
                            if (options != null && String.Equals(options.CustomDllName, dll, StringComparison.OrdinalIgnoreCase))
                            {
                                yield return qa;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Properties

        public string Code => CodeCDATA?.InnerText;

        public XmlCDATA CodeCDATA
        {
            get
            {
                var firstCData = ReadNode?.Children.OfType<XmlCDATA>().FirstOrDefault();
                return firstCData;
            }
        }

        #endregion

        #region IRelationManager

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            bool hasOptionGroup = false;

            string options = Options?.Value;
            if (options != null)
            {
                string[] oo = options.Split(new char[] { ';' });
                foreach (string o in oo)
                {
                    if (String.Equals(o.Trim(), "group", StringComparison.OrdinalIgnoreCase))
                    {
                        hasOptionGroup = true;
                    }
                }
            }

            var tr = Triggers?.Value;
            if (tr != null)
            {
                string[] tt = tr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string t in tt)
                {
                    if (hasOptionGroup)
                    {
                        yield return new Reference(this, Mappings.GroupsById, t, this, reverse: true);
                    }
                    else
                    {
                        yield return new Reference(this, Mappings.ParamsById, t, this, reverse: true);
                    }
                }
            }

            var ip = InputParameters?.Value;
            if (ip != null)
            {
                string[] tt = ip.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string t in tt)
                {
                    yield return new Reference(this, Mappings.ParamsById, t, this, isLogic: false, reverse: true);
                }
            }

            foreach (var referencedQAction in GetReferencedQActions())
            {
                var qactionId = Convert.ToString(referencedQAction.Id?.Value);
                yield return new Reference(this, Mappings.QActionsById, qactionId, this, isLogic: false);
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

        #endregion
    }
}