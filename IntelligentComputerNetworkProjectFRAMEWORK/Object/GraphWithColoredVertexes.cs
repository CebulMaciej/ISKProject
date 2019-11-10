using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Object
{
    public class GraphWithColoredVertexes : Graph
    {
        public GraphWithColoredVertexes(Graph graph,IDictionary<int,int> vertexesWithColor) : base(graph.QuantityOfEdges, graph.Edges)
        {
            VertexesWithColor = vertexesWithColor;
        }
        public IDictionary<int,int> VertexesWithColor { get; }

        public string PrintGraphColors()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<int, int> item in VertexesWithColor)
            {
                stringBuilder.AppendLine($"Vertex :{item.Key} - Color : {item.Value}");
            }
            return stringBuilder.ToString();
        }
    }
}
