namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Skyline.DataMiner.CICD.Models.Protocol.Models.Custom_Classes;
    using Skyline.DataMiner.CICD.Parsers.Common.Xml;
    using Skyline.DataMiner.CICD.Models.Protocol.Read.Interfaces;

    public abstract class ProtocolTag : IProtocolTag
    {
        #region Private variables

        protected readonly ProtocolModel protocolModel;
        protected bool initialLoad = true;

        #endregion

        protected ProtocolTag(ProtocolModel protocolModel, ProtocolTag parent, string tagName)
        {
            this.protocolModel = protocolModel;
            Parent = parent;
            TagName = tagName;
        }

        #region Public properties

        public string TagName { get; private set; }

        public XmlElement ReadNode { get; private set; }

        public virtual XmlAttribute ReadAttribute => null;

        public IProtocolModel Model { get { return protocolModel; } }

        public IReadable Parent { get; private set; }

        #endregion

        /// <summary>
        /// Returns the first parent of type <typeparamref name="T"/>.
        /// </summary>
        public T TryFindParent<T>() where T : IReadable
        {
            var parent = Parent;

            while (parent != null)
            {
                if (parent is T result)
                {
                    return result;
                }
                parent = parent.Parent;
            }

            return default(T);
        }

        public static T ConvertRawValue<T>(string rawValue)
        {
            if (rawValue is T t)
            {
                return t;
            }

            try
            {
                if (!String.IsNullOrEmpty(rawValue))
                {
                    var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

                    if (type == typeof(TimeSpan))
                    {
                        return (T)(object)System.Xml.XmlConvert.ToTimeSpan(rawValue);
                    }
                    else
                    {
                        return (T)Convert.ChangeType(rawValue, type, CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (InvalidCastException)
            {
                //Conversion is not unsupported
            }
            catch (FormatException)
            {
                //string input value was in incorrect format
            }
            catch (OverflowException)
            {
                //narrowing conversion between two numeric types results in loss of data
            }

            return default(T);
        }

        internal void ParseAttributeTag<T>(string attributeName, string propertyName, T variable, Action<T> setter) where T : ProtocolTag
        {
            var attribute = ReadNode.Attribute[attributeName];
            if (attribute == null)
            {
                setter(null);
                if (variable != null)
                {
                    NotifyPropertyChanged(propertyName);
                    protocolModel.NotifyRemoved(variable);
                }
            }
            else
            {
                if (variable == null)
                {
                    // Don't change order of this procedure
                    var type = typeof(T);

                    if (!ModelObjectActivator<ProtocolModel, ProtocolTag, string, T>.TryCreate(type, protocolModel, this, attributeName, out variable)
                        && !ModelObjectActivator<ProtocolModel, ProtocolTag, T>.TryCreate(type, protocolModel, this, out variable))
                    {
                        var availableConstructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                        throw new InvalidOperationException("No matching constructor found in type '" + type + "'. Available constructors:\n"
                                                            + String.Join("\n", availableConstructors.Select(x => " - " + x)));
                    }

                    variable.Update(ReadNode, propertyName);
                    setter(variable);

                    NotifyPropertyChanged(propertyName);
                    protocolModel.NotifyAdded(variable);
                }
                else
                {
                    if (variable.Update(ReadNode, propertyName))
                    {
                        protocolModel.NotifyUpdated(variable);
                    }
                }
            }
        }

        internal void ParseElementTag<T>(string tagName, string propertyName, T variable, Action<T> setter)
            where T : ProtocolTag
        {
            var node = ReadNode.Element[tagName];
            if (node == null)
            {
                setter(null);
                if (variable != null)
                {
                    NotifyPropertyChanged(propertyName);
                    protocolModel.NotifyRemoved(variable);
                }
            }
            else
            {
                if (variable == null)
                {
                    var type = typeof(T);

                    if (!ModelObjectActivator<ProtocolModel, ProtocolTag, string, T>.TryCreate(type, protocolModel, this, tagName, out variable)
                        && !ModelObjectActivator<ProtocolModel, ProtocolTag, T>.TryCreate(type, protocolModel, this, out variable))
                    {
                        var availableConstructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                        throw new InvalidOperationException("No matching constructor found in type '" + type + "'. Available constructors:\n"
                                                            + String.Join("\n", availableConstructors.Select(x => " - " + x)));
                    }

                    // Don't change order of this procedure
                    variable.Update(node, propertyName);
                    setter(variable);

                    NotifyPropertyChanged(propertyName);
                    protocolModel.NotifyAdded(variable);
                }
                else
                {
                    if (variable.Update(node, propertyName))
                    {
                        variable.NotifyPropertyChanged(propertyName);
                        protocolModel.NotifyUpdated(variable);
                    }
                }
            }
        }

        bool IProtocolTag.Update(XmlElement readNode, string propertyName)
        {
            return Update(readNode, propertyName);
        }

        internal bool Update(XmlElement readNode, string propertyName)
        {
            if (readNode == null)
            {
                throw new ArgumentNullException("readNode");
            }

            if (ReadNode != readNode)
            {
                ReadNode = readNode;
                Parse(propertyName);

                // The makes sure that when we create a new element, the events on that specific object do not trigger.
                if (initialLoad)
                {
                    initialLoad = false;
                }

                return true;
            }

            return false;
        }
        protected abstract void Parse(string notifyPropertyName);

        public abstract void Accept(ProtocolVisitor visitor);

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (!initialLoad)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public override string ToString()
        {
            var idAttr = ReadNode.Attribute["id"];
            if (idAttr != null)
            {
                return TagName + " [" + idAttr.Value + "]";
            }
            else
            {
                return TagName;
            }
        }

    }
}