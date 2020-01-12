using System.Collections.Generic;
using System.Linq;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Object
{
    public class Graph
    {
        public Graph(int quantityOfEdges, IList<Edge> edges)
        {
            QuantityOfEdges = quantityOfEdges;
            Edges = edges;
            Vertexes = edges.Select(x => x.SourceVertex).Union(edges.Select(y => y.TargetVertex)).Distinct().OrderBy(p=>p).ToList();
        }
        public int QuantityOfEdges { get; }
        public IList<Edge> Edges { get; }
        public IList<int> Vertexes { get; }

        public IList<int> NeighborsList(int vertex)
        {
            IEnumerable<int> vertexFromStarting= Edges.Where(x => x.SourceVertex == vertex).Select(x => x.TargetVertex);
            IEnumerable<int> vertexFromEnding= Edges.Where(x => x.TargetVertex == vertex).Select(x => x.SourceVertex);
            return vertexFromEnding.Union(vertexFromStarting).Distinct().ToList();
        }
        public virtual string PrintGraphInOriginalForm() => Edges.Aggregate($"<{QuantityOfEdges}>", (current, edge) => $"{current}{edge.PrintEdgeInOriginalForm}");
        
    }
}
