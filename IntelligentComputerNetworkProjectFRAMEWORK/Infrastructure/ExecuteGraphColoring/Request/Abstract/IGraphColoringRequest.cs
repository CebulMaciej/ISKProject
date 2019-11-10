using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Request.Abstract
{
    public interface IGraphColoringRequest
    {
        int[] StartValues { get; }
        int Population { get; }
        int PopulationSize { get; }
        Graph Graph { get; }
    }
}
