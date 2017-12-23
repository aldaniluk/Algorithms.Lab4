using GraphView;
using System;
using System.Collections.Generic;
using Algorithms;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Edge> edges1 = new List<Edge>() {
                new Edge(0,1,1),
                new Edge(0,6,1),
                new Edge(0,9,3),
                new Edge(0,10,2),
                new Edge(1,2,1),
                new Edge(1,3,2),
                new Edge(1,4,1),
                new Edge(2,3,4),
                new Edge(3,4,3),
                new Edge(4,5,4),
                new Edge(5,6,3),
                new Edge(6,7,4),
                new Edge(6,8,3),
                new Edge(7,8,4),
                new Edge(7,9,2),
                new Edge(8,9,1),
                new Edge(9,10,3)
            };
            Graph gr1 = new Graph(edges1);

            #region Kruskal
            Console.WriteLine("----------Kruskal--------");
            var spanningTree1 = GetSpanningTree.Kruskal(gr1);

            Console.WriteLine($"Total weight: {spanningTree1.Item2}");

            foreach(var i in spanningTree1.Item1.Edges)
            {
                Console.Write($"({i.First} {i.Second}) ");
            }
            Console.WriteLine("\n---------//Kruskal-------\n");
            #endregion

            #region Prim
            Console.WriteLine("------------Prim---------");
            var spanningTree2 = GetSpanningTree.Prim(gr1);

            Console.WriteLine($"Total weight: {spanningTree1.Item2}");

            foreach (var i in spanningTree2.Item1.Edges)
            {
                Console.Write($"({i.First} {i.Second}) ");
            }
            Console.WriteLine("\n-----------//Prim--------\n");
            #endregion
        }
    }
}
