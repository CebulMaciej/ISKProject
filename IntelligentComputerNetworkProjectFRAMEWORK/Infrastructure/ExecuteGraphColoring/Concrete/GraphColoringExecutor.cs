using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete.ColoringMembers.GeneticObjects;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Request.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Concrete;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete
{
    public class GraphColoringExecutor : IGraphColoringExecutor
    {
        public IGraphColoringResponse ColorGraph(IGraphColoringRequest graphColoringRequest)
        {
            try
            {
                Graph graph = graphColoringRequest.Graph;
                GraphProvider.SetGraph(graph);

                Console.WriteLine(graph.PrintGraphInOriginalForm());
                
                CPChromosome chromosome = new CPChromosome(graphColoringRequest.StartValues.Length, graphColoringRequest.StartValues, graphColoringRequest.Population);
                Population population = new Population(graphColoringRequest.PopulationSize, graphColoringRequest.PopulationSize, chromosome);
                CPFitness fitness = new CPFitness();
                EliteSelection selection = new EliteSelection();
                OnePointCrossover crossover = new OnePointCrossover();
                CPMutation mutation = new CPMutation();
                FitnessStagnationTermination termination = new FitnessStagnationTermination(50);
                GeneticAlgorithm ga = new GeneticAlgorithm(population,fitness,selection,crossover,mutation)
                    { Termination = termination, MutationProbability = 0.1f };
                int latestFitness = int.MinValue;
                int bestFitness = 0;
                CPChromosome bestChromosome=null;
                ga.GenerationRan += (sender, e) =>
                {
                    bestChromosome = ga.BestChromosome as CPChromosome;
                    bestFitness = (int)-bestChromosome.Fitness.Value;

                    if (bestFitness == latestFitness) return;
                    latestFitness = bestFitness;
                    bestChromosome.GetValues();
                    Console.WriteLine("Current Generation Result : {0}", bestFitness);
                };
                ga.TerminationReached += (sender, e) => { Console.WriteLine("This is the end of generations"); };
                ga.Start();
                
                Console.WriteLine("End");

                if(bestFitness > graph.Vertexes.Count) return new GraphColoringResponse();

                int[] resultGenType = bestChromosome.GetValues();
                
                IDictionary<int,int> coloredVertex = new Dictionary<int, int>(graph.Vertexes.Count);

                foreach (int vertex in graph.Vertexes)
                {
                    coloredVertex.Add(vertex, resultGenType[vertex-1]);
                }
                GraphWithColoredVertexes coloredGraph = new GraphWithColoredVertexes(graph,coloredVertex);

                return new GraphColoringResponse(coloredGraph);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new GraphColoringResponse();
            }
        }
    }
}
