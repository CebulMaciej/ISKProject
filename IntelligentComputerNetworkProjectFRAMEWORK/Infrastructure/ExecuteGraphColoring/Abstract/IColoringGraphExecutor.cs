using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract
{
    public interface IColoringGraphExecutor
    {
        IGraphColoringResponse ColorGraph(ColorGraphParameters parameters);
    }
}
