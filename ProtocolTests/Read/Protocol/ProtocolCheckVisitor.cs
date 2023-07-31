namespace Models.ProtocolTests.Read.Protocol
{
    using System;
    using Skyline.DataMiner.CICD.Models.Protocol.Read;

    public class ProtocolCheckVisitor : ProtocolVisitor
    {
        private readonly Action<IReadable> check;

        public ProtocolCheckVisitor(Action<IReadable> check)
        {
            this.check = check;
        }

        public override void DefaultVisit(IReadable obj)
        {
            check(obj);
        }
    }
}
