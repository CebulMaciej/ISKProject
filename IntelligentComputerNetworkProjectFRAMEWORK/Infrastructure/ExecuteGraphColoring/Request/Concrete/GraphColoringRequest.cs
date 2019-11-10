using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Request.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Request.Concrete
{
    public class GraphColoringRequest : IGraphColoringRequest
    {
        public GraphColoringRequest(int[] startValues, int population, int populationSize, Graph graph)
        {
            StartValues = startValues;
            Population = population;
            PopulationSize = populationSize;
            Graph = graph;
        }

        public int[] StartValues { get; }
        public int Population { get; }
        public int PopulationSize { get; }
        public Graph Graph { get; }
    }
}
