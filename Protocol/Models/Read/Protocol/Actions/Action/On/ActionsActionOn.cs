namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System;
    using System.Collections.Generic;

    internal partial class ActionsActionOn : IActionsActionOn
    {
        public IReadOnlyList<uint> GetId()
        {
            if (Id?.Value == null)
            {
                return new List<uint>(0);
            }

            string[] parts = Id.Value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            List<uint> ids = new List<uint>();
            foreach (var part in parts)
            {
                if (UInt32.TryParse(part, out uint id))
                {
                    ids.Add(id);
                }
            }

            return ids;
        }
    }
}