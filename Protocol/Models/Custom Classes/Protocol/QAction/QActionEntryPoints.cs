namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    public class QActionEntryPoints : OptionsBase
    {
        public QActionEntryPoints(string value) : base(value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                EntryPoints = new EntryPoint[]
                {
                    new EntryPoint(0, className:null, methodName:null),
                };

                return;
            }

            string[] entryPoints = value.Split(';');

            var tempEntryPoints = new EntryPoint[entryPoints.Length];
            for (uint i = 0; i < entryPoints.Length; i++)
            {
                int lastDotPos = entryPoints[i].LastIndexOf('.');
                if (lastDotPos > -1)
                {
                    string className = entryPoints[i].Substring(0, lastDotPos);
                    string methodName = entryPoints[i].Substring(lastDotPos + 1);

                    tempEntryPoints[i] = new EntryPoint(i, className, methodName);
                }
                else
                {
                    tempEntryPoints[i] = new EntryPoint(i, className: null, methodName: entryPoints[i]);
                }
            }

            EntryPoints = tempEntryPoints;
        }

        public IReadOnlyList<EntryPoint> EntryPoints { get; }

        public class EntryPoint
        {
            public uint Position { get; private set; }

            public string ClassName { get; private set; }

            public string MethodName { get; private set; }

            private const string DefaultClassName = "QAction";
            private const string DefaultMethodName = "Run";

            public EntryPoint(uint position, string className, string methodName)
            {
                Position = position;
                ClassName = className;
                MethodName = methodName;
            }

            public string GetClassNameOrDefault()
            {
                return ClassName ?? DefaultClassName;
            }

            public string GetMethodNameOrDefault()
            {
                return MethodName ?? DefaultMethodName;
            }
        }
    }
}
