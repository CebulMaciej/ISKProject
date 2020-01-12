using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract
{
    public interface IGraphColoringResponse
    {
        bool Success { get; }
        GraphWithColoredVertexes ColoredGraph { get; }
    }
}
