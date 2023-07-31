namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a protocol page.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="name">The page name.</param>
        public Page(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the page name (uppercased).
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this page is a popup page.
        /// </summary>
        /// <value><c>true</c> in case this page is a popup page; otherwise, <c>false</c>.</value>
        public bool IsPopup { get; set; }

        /// <summary>
        /// List of parameters displayed on the page.
        /// </summary>
        public List<IParamsParam> Params { get; set; } = new List<IParamsParam>();
    }
}