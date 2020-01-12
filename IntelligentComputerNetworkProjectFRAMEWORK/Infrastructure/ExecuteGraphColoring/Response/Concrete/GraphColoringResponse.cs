using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Concrete
{
    public class GraphColoringResponse : IGraphColoringResponse
    {
        public GraphColoringResponse(GraphWithColoredVertexes coloredGraph)
        {
            ColoredGraph = coloredGraph;
            Success = true;
        }

        public GraphColoringResponse()
        {
        }

        public bool Success { get; }
        public GraphWithColoredVertexes ColoredGraph { get; }
    }
}
