using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract
{
    public interface IGraphColoringExecutor
    {
        IGraphColoringResponse ColorGraph(ColorGraphParameters parameters);
    }
}
