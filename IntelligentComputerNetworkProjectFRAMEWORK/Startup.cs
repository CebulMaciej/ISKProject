using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.GraphInterpretation;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;
using IntelligentComputerNetworkProjectFRAMEWORK.Object.Const;
using System;

namespace IntelligentComputerNetworkProjectFRAMEWORK
{
    public class Startup
    {
        public void Run()
        {
            IGraphColoringExecutor coloringExecutor = new GraphColoringExecutor();

            InitGraph();
            ColorGraphParameters colorGraphParameters = GetColorGraphParameters();

            IGraphColoringResponse response = coloringExecutor.ColorGraph(colorGraphParameters);
            ShowResult(response);
        }

        private ColorGraphParameters GetColorGraphParameters()
        {
            Console.WriteLine("--Parameters--");
            Console.Write("Min population size: ");
            int minPopulationSize = int.Parse(Console.ReadLine());

            Console.Write("Max population size: ");
            int maxPopulationSize = int.Parse(Console.ReadLine());

            Console.Write("Max number of generations: ");
            int maxNumberOfGenerations = int.Parse(Console.ReadLine());

            return new ColorGraphParameters(minPopulationSize, maxPopulationSize, maxNumberOfGenerations,
                SelectionType.Elite, CrossoverType.OnePoint, TimeSpan.FromMinutes(5));
        }

        private void InitGraph()
        {
            GraphInterpreter graphInterpreter = new GraphInterpreter();
            Graph graph = graphInterpreter.GetDefaultGraph();
            GraphProvider.SetGraph(graph);
            Console.WriteLine("Graph form:" + graph.PrintGraphInOriginalForm());
        }



        private void ShowResult(IGraphColoringResponse response)
        {
            GraphWithColoredVertexes gr = response.ColoredGraph;
            Console.WriteLine(gr.PrintGraphColors());
        }

        //private static Graph PrepareGraphWithColoringParameters(string path, out int[] startValues)
        //{
        //    GraphInterpreter graphInterpreter = new GraphInterpreter(path);
        //    Graph graph = graphInterpreter.GetGraph;

        //    startValues = graph.Vertexes.ToArray();
        //    return graph;
        //}
    }
}
