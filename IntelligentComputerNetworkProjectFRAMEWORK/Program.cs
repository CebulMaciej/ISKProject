using System;
using System.Linq;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Request.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Request.Concrete;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.GraphInterpretation;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK
{
    public class Program
    {
        private static IGraphColoringExecutor ColoringExecutor { get; } = new GraphColoringExecutor();

        private static void Main()
        {
            try
            {
                GetEntryParameters(out var population, out var populationSize,out string path);

                Graph graph = PrepareGraphWithColoringParameters(path, out var startValues);

                IGraphColoringRequest request = new GraphColoringRequest(startValues,population,populationSize,graph);
                
                IGraphColoringResponse response = ColoringExecutor.ColorGraph(request);

                ShowResult(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }

        private static void ShowResult(IGraphColoringResponse response)
        {
            GraphWithColoredVertexes gr = response.ColoredGraph;

            Console.WriteLine(gr.PrintGraphColors());
        }

        private static Graph PrepareGraphWithColoringParameters(string path, out int[] startValues)
        {
            GraphInterpreter graphInterpreter = new GraphInterpreter(path);
            Graph graph = graphInterpreter.GetGraph;

            startValues = graph.Vertexes.ToArray();
            return graph;
        }

        private static void GetEntryParameters(out int population, out int populationSize,out string path)
        {
            path = EnterFilePath();

            population = EnterPopulationCount();

            populationSize = EnterPopulationSize();
        }

        private static int EnterPopulationSize()
        {
            Console.WriteLine("Give the population size :");
            string populationSize = Console.ReadLine();
            return int.Parse(populationSize ?? throw new InvalidOperationException());
        }

        private static int EnterPopulationCount()
        {
            Console.WriteLine("Give the population count :");
            string population = Console.ReadLine();
            return int.Parse(population ?? throw new InvalidOperationException());
        }

        private static string EnterFilePath()
        {
            Console.WriteLine("Give the file path :");
            string path = Console.ReadLine();
            return path;
        }
    }
}
