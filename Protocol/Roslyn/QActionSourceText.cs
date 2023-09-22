namespace Skyline.DataMiner.CICD.Models.Protocol
{
    using System;
    using System.Text;

    using Microsoft.CodeAnalysis.Text;

    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    internal class QActionSourceText : SourceText
    {
        private readonly SourceText _source;

        public IQActionsQAction QAction { get; }

        public QActionSourceText(IQActionsQAction qAction)
        {
            if (qAction == null)
            {
                throw new ArgumentNullException(nameof(qAction));
            }

            _source = From(qAction.Code);
            QAction = qAction;
        }

        public override void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            _source.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public override Encoding Encoding => _source.Encoding;

        public override int Length => _source.Length;

        public override char this[int position] => _source[position];
    }
}
