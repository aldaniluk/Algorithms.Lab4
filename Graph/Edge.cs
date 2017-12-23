namespace GraphView
{
    public struct Edge
    {
        public int First { get; }
        public int Second { get; }

        public int Weight { get; }

        public Edge(int first, int second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }
    }
}
