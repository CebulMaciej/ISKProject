using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete.ColoringMembers.GeneticObjects;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.GeneticObjects;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Concrete;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.GeneticTermination;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;
using IntelligentComputerNetworkProjectFRAMEWORK.Object.Const;
using System;
using System.Collections.Generic;
using System.Threading;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete
{
    public class ColoringGraphExecutor : IColoringGraphExecutor
    {
        public IGraphColoringResponse ColorGraph(ColorGraphParameters parameters)
        {
            try
            {
                Graph graph = GraphProvider.Graph;


                TerminationBuilder terminationBuilder = new TerminationBuilder();

                GCPChromosome chromosome = new GCPChromosome(1, graph.Vertexes.Count, graph.Vertexes.Count);

                foreach (var item in chromosome.GetValues())
                {
                    Console.WriteLine(item);
                }

                Population population = new Population(parameters.MinPopulationSize, parameters.MaxPopulationSize, chromosome);
                GCPFitness fitness = new GCPFitness();
                EliteSelection selection = new EliteSelection();
                OnePointCrossover crossover = new OnePointCrossover();
                //CPMutation mutation = new CPMutation();
                UniformMutation mutation = new UniformMutation(true);

                GeneticAlgorithm ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
                {
                    Termination = terminationBuilder.BuildTermination(parameters),
                    MutationProbability = parameters.MutationProbability,
                    CrossoverProbability = parameters.CrossoverProbability
                };


                //int latestFitness = int.MinValue;
                int bestFitness = 0;
                GCPChromosome bestChromosome = null;
                ga.GenerationRan += (sender, e) =>
                {
                    //bestChromosome = ga.BestChromosome as GCPChromosome;
                    //bestFitness = (int)-bestChromosome.Fitness.Value;

                    bestChromosome = (GCPChromosome)ga.Population.BestChromosome;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
                    Console.WriteLine("Fitness: {0}", (int)bestChromosome.Fitness.Value);
                    Console.WriteLine("Time: {0}", ga.TimeEvolving);
                    Thread.Sleep(50);

                    //if (bestFitness == latestFitness) return;
                    //latestFitness = bestFitness;
                    //Console.WriteLine("Current Generation Result : {0}", bestFitness);
                };
                ga.TerminationReached += (sender, e) => { Console.WriteLine("This is the end of generations"); };
                ga.Start();

                Console.WriteLine("End");

                if (bestFitness > graph.Vertexes.Count) return new GraphColoringResponse();

                int[] resultGenType = bestChromosome.GetValues();

                IDictionary<int, int> coloredVertex = new Dictionary<int, int>(graph.Vertexes.Count);

                foreach (int vertex in graph.Vertexes)
                {
                    coloredVertex.Add(vertex, resultGenType[vertex - 1]);
                }
                GraphWithColoredVertexes coloredGraph = new GraphWithColoredVertexes(graph, coloredVertex);

                return new GraphColoringResponse(coloredGraph);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new GraphColoringResponse();
            }
        }

        private ISelection GetSelectionMethod(SelectionType selectionType)
        {
            switch (selectionType)
            {
                case SelectionType.Elite:
                    return new EliteSelection();

                case SelectionType.RouletteWheel:
                    return new RouletteWheelSelection();

                case SelectionType.Tournament:
                    return new TournamentSelection();
            }
            throw new KeyNotFoundException();
        }
    }
}
