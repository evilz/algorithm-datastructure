namespace DataStructure.Set
{
    /// <summary>
    /// The Union-find data type (also known as the<em> disjoint-sets data type</em>).
    /// </summary>
    public interface IUnionFind
    {
        /// <summary>
        /// Returns true if the the two items are in the same set.
        /// </summary>
        bool IsConnected(int p, int q);

        /// <summary>
        /// (Union method) Merges the set containing item <tt>p</tt> with the set containing item<tt>q</tt>.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        void Connect(int p, int q);

        /// <summary>
        /// Returns the set identifier for the set containing item <tt>p</tt>.
        /// </summary>
        int Find(int p);

        /// <summary>
        /// Returns the number of items.
        /// </summary>
        int Count { get; }
    }
}