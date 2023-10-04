namespace Skyline.DataMiner.CICD.Models.Common
{
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Represents a build result.
    /// </summary>
    internal class CompilationResult
    {
        /// <summary>
        /// Gets or sets the name of the assembly.
        /// </summary>
        /// <value>The name of the assembly.</value>
        public string AssemblyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the build result.
        /// </summary>
        /// <value><c>true</c> if the build succeeded; otherwise, <c>false</c>.</value>
        public bool Result { get; set; }

        /// <summary>
        /// Gets or sets the compilation errors.
        /// </summary>
        /// <value>The compilation errors.</value>
        public IList<Diagnostic> CompilationErrors { get; set; }

        /// <summary>
        /// Gets or sets the compilation.
        /// </summary>
        /// <value>The compilation.</value>
        public Compilation Compilation { get; set; }
    }
}
