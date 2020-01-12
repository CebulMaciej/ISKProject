using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.GeneticObjects;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Concrete;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.GeneticTermination;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ShowInformation;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;
using IntelligentComputerNetworkProjectFRAMEWORK.Object.Const;
using System;
using System.Collections.Generic;

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
                InfoDraftsman info = new InfoDraftsman();

                GCPChromosome chromosome = new GCPChromosome(1, graph.Vertexes.Count, graph.Vertexes.Count);

                Population population = new Population(parameters.MinPopulationSize, parameters.MaxPopulationSize, chromosome);
                GCPFitness fitness = new GCPFitness();
                EliteSelection selection = new EliteSelection();
                ThreeParentCrossover crossover = new ThreeParentCrossover();
                UniformMutation mutation = new UniformMutation(true);

                GeneticAlgorithm ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
                {
                    Termination = terminationBuilder.BuildTermination(parameters),
                    MutationProbability = parameters.MutationProbability,
                    CrossoverProbability = parameters.CrossoverProbability
                };

                GCPChromosome bestChromosome = null;
                bool clear = false;
                ga.GenerationRan += (sender, e) =>
                {
                    if (ga.GenerationsNumber % 100 == 0)
                    {
                        if (clear)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            info.ClearConsoleLines(new int[] { Console.CursorTop, Console.CursorTop - 1, Console.CursorTop - 2, Console.CursorTop - 3, Console.CursorTop - 4 });
                        }
                        clear = true;
                        bestChromosome = (GCPChromosome)ga.Population.BestChromosome;
                        Console.WriteLine();
                        Console.WriteLine("--Runtime--");
                        Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
                        Console.WriteLine("Required colors: {0}", (int)-bestChromosome.Fitness.Value);
                        Console.WriteLine("Time: {0}", ga.TimeEvolving);
                    }
                };
                ga.TerminationReached += (sender, e) => 
                {
                    Console.WriteLine();
                    Console.WriteLine("--Runtime--");
                    Console.WriteLine("Generations: {0}", ga.Population.GenerationsNumber);
                    Console.WriteLine("Required colors: {0}", (int)-bestChromosome.Fitness.Value);
                    Console.WriteLine("Time: {0}", ga.TimeEvolving);
                    Console.WriteLine();
                    Console.WriteLine("Genetic calculation terminated!");
                };
                ga.Start();

                if ((int)-bestChromosome.Fitness.Value > graph.Vertexes.Count)
                {
                    return new GraphColoringResponse();
                }

                return new GraphColoringResponse(PrepareColoredGraph(bestChromosome));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new GraphColoringResponse();
            }
        }

        private GraphWithColoredVertexes PrepareColoredGraph(GCPChromosome bestChromosome)
        {
            Graph graph = GraphProvider.Graph;
            int[] resultGenType = bestChromosome.GetValues();

            IDictionary<int, int> coloredVertex = new Dictionary<int, int>(graph.Vertexes.Count);
            foreach (int vertex in graph.Vertexes)
            {
                coloredVertex.Add(vertex, resultGenType[vertex - 1]);
            }
            return new GraphWithColoredVertexes(graph, coloredVertex);

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
