namespace DataStructure.Set
{
    public class QuickUnion : UnionFindBase
    {
        public QuickUnion(int length) : base(length){}
        
        public override void Connect(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);
            if (rootP == rootQ) { return; }
            Connections[rootP] = rootQ;
            Count--;
        }

        public override int Find(int p)
        {
            Validate(p);
            while (p != Connections[p])
            {
                p = Connections[p];
            }
            return p;
        }
        
        public override bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }
        
    }
}