using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Object
{
    public class Graph
    {
        public Graph(int quantityOfEdges, IList<Edge> edges)
        {
            QuantityOfEdges = quantityOfEdges;
            Edges = edges;
        }
        public int QuantityOfEdges { get; }
        public IList<Edge> Edges { get; }
        public string PrintGraphInOriginalForm() => Edges.Aggregate($"<{QuantityOfEdges}>", (current, edge) => $"{current}{edge.PrintEdgeInOriginalForm}");
        
    }
}
