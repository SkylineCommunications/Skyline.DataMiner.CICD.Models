namespace Skyline.DataMiner.CICD.Models.Common
{
    /// <summary>
    /// Returns the first found full path for the given DLL import.
    /// </summary>
    public interface IAssemblyResolver
    {
        /// <summary>
        /// Tries resolve the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to resolve.</param>
        /// <returns>The resolved assembly</returns>
        string TryResolve(string assembly);

        /// <summary>
        /// Tries resolving the specified assembly. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="assembly">The assembly to resolve.</param>
        /// <param name="resolved">The resolved assembly.</param>
        /// <returns><c>true</c> if s was converted successfully; otherwise, <c>false</c>.</returns>
        bool TryResolve(string assembly, out string resolved);
    }
}
