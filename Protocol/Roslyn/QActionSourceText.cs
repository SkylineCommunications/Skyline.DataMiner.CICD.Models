namespace Skyline.DataMiner.CICD.Models.Protocol
{
    using System;
    using System.Text;

    using Microsoft.CodeAnalysis.Text;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    /// <summary>
    /// Represents QAction source code.
    /// </summary>
    public class QActionSourceText : SourceText
    {
        private readonly SourceText _source;

        /// <summary>
        /// Gets the QAction this source text is part of.
        /// </summary>
        /// <value>The QAction this source text is part of.</value>
        public IQActionsQAction QAction { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QActionSourceText"/> class.
        /// </summary>
        /// <param name="qAction">The QAction.</param>
        /// <exception cref="ArgumentNullException"><paramref name="qAction"/> is <see langword="null"/>.</exception>
        public QActionSourceText(IQActionsQAction qAction)
        {
            if (qAction == null)
            {
                throw new ArgumentNullException(nameof(qAction));
            }

            _source = From(qAction.Code);
            QAction = qAction;
        }

        /// <summary>
        /// Copies a range of characters from this SourceText to a destination array.
        /// </summary>
        /// <param name="sourceIndex">The source index.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="destinationIndex">The destination index.</param>
        /// <param name="count">The number of characters to copy.</param>
        public override void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            _source.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        /// <summary>
        /// Gets the encoding of the file that the text was read from or is going to be saved to. null if the encoding is unspecified.
        /// </summary>
        /// <value>Encoding of the file that the text was read from or is going to be saved to. null if the encoding is unspecified.</value>
        public override Encoding Encoding => _source.Encoding;

        /// <summary>
        /// Gets the length of the text in characters.
        /// </summary>
        /// <value>The length of the text in characters.</value>
        public override int Length => _source.Length;

        /// <summary>
        /// Gets the character at given position.
        /// </summary>
        /// <param name="position">The position to get the character from.</param>
        /// <returns>The character at given position.</returns>
        /// <exception cref="ArgumentOutOfRangeException">When position is negative or greater than <see cref="Length"/>.</exception>
        public override char this[int position] => _source[position];
    }
}
