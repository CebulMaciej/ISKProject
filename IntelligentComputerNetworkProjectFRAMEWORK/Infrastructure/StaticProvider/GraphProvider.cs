using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider
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
