using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
