namespace Skyline.DataMiner.CICD.Models.Protocol.Models.Custom_Classes.Protocol.QAction
{
    using System.Collections.Generic;

    /// <summary>
    /// QAction assembly references helper.
    /// </summary>
    public class QActionAssemblyReferencesHelper
    {
        /// <summary>
        /// Defines the assemblies that are referenced by default in DataMiner when a QAction is compiled.
        /// </summary>
        public static readonly IReadOnlyList<string> DefaultReferencedAssemblies = new List<string>()
        {
            "Interop.SLDms.dll",
            "mscorlib.dll",
            "QactionHelperBaseClasses.dll",
            "Skyline.DataMiner.Storage.Types.dll",
            "SLLoggerUtil.dll",
            "SLManagedScripting.dll",
            "SLNetTypes.dll",
            "System.dll",
            "System.Xml.dll",
            "System.Core.dll",
        };
    }
}
