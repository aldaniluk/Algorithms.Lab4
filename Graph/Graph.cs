using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphView
{
    public class Graph
    {
        public List<Edge> Edges { get; }
        public int Size { get; } //quantity of vertices

        public Graph(IEnumerable<Edge> edges)
        {
            Edges = edges.ToList();
            Size = edges.GroupBy(e => e.First).Count() + 1;
        }

        public Dictionary<int, List<Edge>> ToDictionary()
        {
            Dictionary<int, List<Edge>> result = new Dictionary<int, List<Edge>>();
            foreach (var edge in Edges)
            {
                AddInDictionary(result, edge.First, edge);
                AddInDictionary(result, edge.Second, edge);
            }

            return result;
        }

        private void AddInDictionary(Dictionary<int, List<Edge>> result, int vertex, Edge edge)
        {
            if (result.ContainsKey(vertex))
            {
                result[vertex].Add(edge);
            }
            else
            {
                result[vertex] = new List<Edge>() { edge };
            }
        }
    }
}
