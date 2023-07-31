namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;

    public abstract class OptionsBase
    {
        protected OptionsBase(string optionsAttribute)
        {
            OriginalValue = optionsAttribute;
        }

        /// <summary>
        /// Original value of the option.
        /// </summary>
		public string OriginalValue { get; }
        
        /// <summary>
        /// Returns the original value.
        /// </summary>
        /// <returns>The original value.</returns>
		public override string ToString() => OriginalValue;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is OptionsBase b && String.Equals(b.ToString(), ToString());

        /// <inheritdoc/>
        public override int GetHashCode() => OriginalValue?.GetHashCode() ?? 0;
    }
}