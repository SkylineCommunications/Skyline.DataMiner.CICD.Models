namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    
    using System.Collections.Generic;
    using System.Collections.Specialized;

    public interface IReadableList<out T> : IReadOnlyList<T>, IReadable, INotifyCollectionChanged where T : IReadable
    {
    }
}
