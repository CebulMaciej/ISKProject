using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract
{
    public interface IGraphColoringResponse
    {
        bool Success { get; }
        GraphWithColoredVertexes ColoredGraph { get; }
    }
}
