namespace Protocol.Generator.XSD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Schema;

    internal class ProtocolXsd
    {
        public XmlSchemaElement Root { get; }

        public Element Node { get; private set; }

        public Dictionary<string, EnumList> Enums { get; }

        public Dictionary<string, SchemaType> KnownTypes { get; }

        public ProtocolXsd(string path)
        {
            XmlReader reader = XmlReader.Create(path);
            XmlSchema schema = XmlSchema.Read(reader, (a, b) => { });
            schema.Compile((a, b) => { });

            Enums = new Dictionary<string, EnumList>();
            KnownTypes = new Dictionary<string, SchemaType>();

            foreach (var a in schema.Items)
            {
                if (a is XmlSchemaElement e && Root == null)
                {
                    Root = e;
                }
                else if (TryGetEnumValues(a, out EnumList enumValues))
                {
                    Enums.Add(enumValues.QualifiedName, enumValues);
                }
                else if (a is XmlSchemaType type)
                {
                    if (type is XmlSchemaComplexType)
                    {
                        //if (simpleType.Content is XmlSchemaSimpleTypeUnion stc) ;
                        //x = new Element(null, stc.);
                    }

                    var schemaType = ParseSchemaType(type);
                    KnownTypes.Add(type.QualifiedName.ToString(), schemaType);
                }
            }

            // create tree structure of elements and attributes
            Node = ParseElement(null, Root, "");

        }

        /// <summary>
        /// If the given object is a SimpleType containing only enumeration restrictions, a list will be returned with all the values.
        /// </summary>
        private static bool TryGetEnumValues(XmlSchemaObject obj, out EnumList enumValues)
        {
            enumValues = new EnumList();

            if (obj is not XmlSchemaSimpleType a)
            {
                return false;
            }

            if (a.Content is not XmlSchemaSimpleTypeRestriction b)
            {
                return false;
            }

            foreach (var f in b.Facets)
            {
                if (f is not XmlSchemaEnumerationFacet e)
                {
                    return false;
                }

                var value = new EnumValue(e.Value)
                {
                    Documentation = Tools.TryGetDocumentation(e.Annotation)
                };

                enumValues.Add(value);
            }

            enumValues.Name = a.Name;
            enumValues.QualifiedName = Convert.ToString(a.QualifiedName);
            enumValues.Documentation = Tools.TryGetDocumentation(a.Annotation);

            return true;
        }

        private SchemaType ParseSchemaType(XmlSchemaType type)
        {
            SchemaType n = new SchemaType(type)
            {
                Name = (type.Name ?? "").Trim(),
                Documentation = Tools.TryGetDocumentation(type.Annotation)
            };

            if (type is not XmlSchemaComplexType complexType)
            {
                return n;
            }

            List<XmlSchemaAttribute> allAttributes = new List<XmlSchemaAttribute>();
            allAttributes.AddRange(complexType.Attributes.Cast<XmlSchemaAttribute>());

            if (complexType.ContentModel is XmlSchemaSimpleContent simpleContent)
            {
                var sc = simpleContent.Content as XmlSchemaSimpleContentExtension;
                allAttributes.AddRange(sc.Attributes.Cast<XmlSchemaAttribute>());
            }

            foreach (var a in allAttributes)
            {
                var x = new Attribute(n, a)
                {
                    Name = a.Name,
                    Path = n.Path + "/@" + a.Name,
                    Documentation = Tools.TryGetDocumentation(a.Annotation)
                };

                if (n.Attributes.All(y => y.Name != x.Name))
                {
                    n.Attributes.Add(x);
                }
            }

            var groups = new Queue<XmlSchemaGroupBase>();
            if (complexType.Particle is XmlSchemaGroupBase group)
            {
                groups.Enqueue(group);
            }

            while (groups.Count > 0)
            {
                var grp = groups.Dequeue();

                foreach (var gi in grp.Items)
                {
                    if (gi is XmlSchemaElement c)
                    {
                        var child = ParseElement(n, c, n.Path);
                        if (n.Elements.All(y => y.Name != child.Name))
                        {
                            n.Elements.Add(child);
                        }
                    }
                    else if (gi is XmlSchemaGroupBase g)
                    {
                        groups.Enqueue(g);
                    }
                }
            }

            return n;
        }

        private Element ParseElement(ElementNode parent, XmlSchemaElement e, string parentPath)
        {
            Element n = new Element(parent, e)
            {
                Name = (e.Name ?? "").Trim()
            };

            if (String.IsNullOrEmpty(e.Name))
            {
                n.Path = parentPath;
            }
            else
            {
                n.Path = parentPath + "/" + e.Name;
            }

            n.Documentation = Tools.TryGetDocumentation(e.Annotation);

            if (e.SchemaType is XmlSchemaComplexType complexType)
            {
                List<XmlSchemaAttribute> allAttributes = new List<XmlSchemaAttribute>();
                allAttributes.AddRange(complexType.Attributes.Cast<XmlSchemaAttribute>());

                if (complexType.ContentModel is XmlSchemaSimpleContent simpleContent)
                {
                    var sc = simpleContent.Content as XmlSchemaSimpleContentExtension;
                    allAttributes.AddRange(sc.Attributes.Cast<XmlSchemaAttribute>());
                }

                foreach (var a in allAttributes)
                {
                    var x = new Attribute(n, a)
                    {
                        Name = a.Name,
                        Path = n.Path + "/@" + a.Name,
                        Documentation = Tools.TryGetDocumentation(a.Annotation)
                    };

                    if (n.Attributes.All(y => y.Name != x.Name))
                    {
                        n.Attributes.Add(x);
                    }
                }

                var groups = new Queue<XmlSchemaGroupBase>();
                if (complexType.Particle is XmlSchemaGroupBase group)
                {
                    groups.Enqueue(group);
                }

                while (groups.Count > 0)
                {
                    var grp = groups.Dequeue();

                    foreach (var gi in grp.Items)
                    {
                        if (gi is XmlSchemaElement c)
                        {
                            var child = ParseElement(n, c, n.Path);
                            if (n.Elements.All(y => y.Name != child.Name))
                            {
                                n.Elements.Add(child);
                            }
                        }
                        else if (gi is XmlSchemaGroupBase g)
                        {
                            groups.Enqueue(g);
                        }
                    }
                }
            }
            else
            {
                string type = e.SchemaTypeName.ToString();

                if (!String.IsNullOrEmpty(type) && KnownTypes.TryGetValue(type, out SchemaType knownType))
                {
                    XmlSchemaElement ee = new XmlSchemaElement
                    {
                        SchemaType = knownType.Definition
                    };
                    var dummy = ParseElement(n, ee, n.Path);
                    foreach (var x in dummy.Elements)
                    {
                        if (n.Elements.All(y => y.Name != x.Name))
                        {
                            n.Elements.Add(x);
                        }
                    }

                    foreach (var x in dummy.Attributes)
                    {
                        if (n.Attributes.All(y => y.Name != x.Name))
                        {
                            n.Attributes.Add(x);
                        }
                    }
                }
            }

            return n;
        }
    }
}
