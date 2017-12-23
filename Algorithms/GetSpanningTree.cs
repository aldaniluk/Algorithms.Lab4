using GraphView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class GetSpanningTree
    {
        //returns spanning tree (using Kruskal algorithm) and total weight
        public static Tuple<Graph, int> Kruskal(Graph graph)
        {
            List<Edge> result = new List<Edge>(); //result spanning tree

            List<Edge> orderedEdgeList = graph.Edges.OrderBy(g => g.Weight).ToList(); //sort edges by weight

            int[] visited = new int[graph.Size];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = i; //unique mark
            }

            for (int i = 0; i < orderedEdgeList.Count; i++)
            {
                int firstVertex = orderedEdgeList[i].First;
                int secondVertex = orderedEdgeList[i].Second;

                if (visited[firstVertex] != visited[secondVertex]) //if there won't cycles
                {
                    result.Add(orderedEdgeList[i]); //add edge

                    int max = Math.Max(visited[firstVertex], visited[secondVertex]);

                    int firstVertexMark = visited[firstVertex];
                    int secondVertexMark = visited[secondVertex];

                    for (int j = 0; j < visited.Length; j++) //mark all vertices in this component with same mark
                    {
                        if (visited[j] == firstVertexMark || visited[j] == secondVertexMark)
                        {
                            visited[j] = max;
                        }
                    }
                }
            }

            return Tuple.Create(new Graph(result), result.Sum(e => e.Weight));
        }

        //returns spanning tree (using Prim algorithm) and total weight
        public static Tuple<Graph, int> Prim(Graph graph)
        {
            List<Edge> result = new List<Edge>(); 
            bool[] visited = new bool[graph.Size]; //mark visited vertices to avoid cycles

            Dictionary<int, List<Edge>> dictionaryGraph = graph.ToDictionary(); 
            HashSet<Edge> connectedEdges = new HashSet<Edge>();

            Edge currentEdge = graph.Edges.OrderBy(g => g.Weight).First(); //get first edge with min weight

            while (visited.Contains(false)) //if result graph is not connected
            {
                dictionaryGraph[currentEdge.First].Remove(currentEdge); //removes from graph in dictionary representation
                dictionaryGraph[currentEdge.Second].Remove(currentEdge);
                connectedEdges.Remove(currentEdge); //removes from list of connected edges

                connectedEdges.UnionWith(dictionaryGraph[currentEdge.First]); //add connected with first edge edges
                connectedEdges.UnionWith(dictionaryGraph[currentEdge.Second]); //add connected with second edge edges

                result.Add(currentEdge);

                visited[currentEdge.First] = true;
                visited[currentEdge.Second] = true;

                //choose edge with min weight among connected
                List<Edge> currentEdgeList = connectedEdges.OrderBy(e => e.Weight).ToList();
                IEnumerator<Edge> enumerator = currentEdgeList.GetEnumerator();
                while (enumerator.MoveNext() && visited[currentEdge.First] && visited[currentEdge.Second])
                {
                    currentEdge = enumerator.Current;
                }
            }

            return Tuple.Create(new Graph(result), result.Sum(e => e.Weight));
        }
    }
}
