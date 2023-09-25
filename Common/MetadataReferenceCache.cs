namespace Skyline.DataMiner.CICD.Models.Common
{
    using System;
    using System.Collections.Concurrent;

    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Represents a cache for metadata references.
    /// </summary>
    public static class MetadataReferenceCache
    {
        private static readonly ConcurrentDictionary<string, Entry> cache = new ConcurrentDictionary<string, Entry>();

        /// <summary>
        /// Creates a new instance of <see cref="MetadataReference"/> for the given path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="MetadataReference"/> instance.</returns>
        /// <exception cref="ArgumentException"><paramref name="path"/> is <see langword="null"/> or whitespace.</exception>
        public static MetadataReference CreateFromFile(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or whitespace", nameof(path));
            }

            var entry = cache.GetOrAdd(path, (p) => new Entry(p));
            return entry.GetReference();
        }

        class Entry
        {
            private readonly string path;
            private WeakReference<MetadataReference> weakref;

            internal Entry(string path)
            {
                this.path = path;
            }

            public MetadataReference GetReference()
            {
#pragma warning disable S2551 // Shared resources should not be used for locking
                lock (this)
#pragma warning restore S2551 // Shared resources should not be used for locking
                {
                    if (weakref == null || !weakref.TryGetTarget(out MetadataReference mref))
                    {
                        mref = MetadataReference.CreateFromFile(path);
                        weakref = new WeakReference<MetadataReference>(mref);
                    }

                    return mref;
                }
            }
        }
    }
}
