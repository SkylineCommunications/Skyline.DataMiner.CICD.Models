namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Helper class for parsing.
    /// </summary>
    public static class ParsingHelper
    {
        /// <summary>
        /// Retrieves the value of the option with the specified prefix from the provided options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="optionPrefix">The option prefix.</param>
        /// <param name="separator">The option separator.</param>
        /// <returns>The value of the specified option or <see langword="null" /> if the option is not found.</returns>
        /// <example>
        /// <code>string newThreshold = ParsingHelper.GetOptionValue(newOptions, "threshold:");</code>
        /// </example>
        public static string GetOptionValue(IValueTag<string> options, string optionPrefix, char separator = ';')
        {
            if (options?.Value == null)
            {
                return null;
            }

            string[] newOptionsSplit = options.Value.Split(separator);

            string result = null;
            foreach (string newOption in newOptionsSplit)
            {
                if (newOption.StartsWith(optionPrefix))
                {
                    result = newOption.Substring(optionPrefix.Length);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Will try to match with Regex.
        /// </summary>
        /// <param name="input">Input text.</param>
        /// <param name="pattern">Pattern to match.</param>
        /// <param name="match">Match from Regex.</param>
        /// <returns>True when the match was a success.</returns>
        public static bool TryMatchRegex(string input, string pattern, out Match match)
        {
            match = Regex.Match(input, pattern);
            return match.Success;
        }
    }
}