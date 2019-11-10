using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentComputerNetworkProjectFRAMEWORK.GraphInterpretation;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.StaticProvider
{
    public static class GraphProvider
    {
        public static Graph Graph { get; private set; }

        public static void SetGraph(Graph graph)
        {
            Graph = graph;
        }


    }
}
