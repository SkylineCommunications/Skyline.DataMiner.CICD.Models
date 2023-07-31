namespace Skyline.DataMiner.CICD.Models.Protocol.Read.Linking
{
    public class Link
    {
        public IReadable Source { get; private set; }
        public IReadable Target { get; private set; }
        public Reference Reference { get; private set; }

        public Link( IReadable source, IReadable target, Reference reference)
        {
            Source = source;
            Target = target;
            Reference = reference;
        }
    }
}
