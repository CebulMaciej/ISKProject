using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.GeneticObjects
{

    public class GCPFitness : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {
            try
            {
                GCPChromosome localChromosome = chromosome as GCPChromosome;
                if (localChromosome == null) throw new InvalidProgramException("Chromosome cannot be null");

                int[] chromosomeValues = localChromosome.GetValues();
                Graph graph = GraphProvider.Graph;

                if (IsColoringCorrect(graph, chromosomeValues, out int countOfBadColoring))
                {
                    return -GetNumberOfRequiredColors(chromosomeValues);
                }

                return -(graph.Vertexes.Count + countOfBadColoring);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return int.MinValue;
            }
        }

        private bool IsColoringCorrect(Graph graph, int[] chromosomeValues, out int countOfBadColoring)
        {
            bool hasAnyNeighborSameColor = false;
            countOfBadColoring = 0;

            foreach (int vertex in graph.Vertexes)
            {
                IList<int> neighbors = graph.NeighborsList(vertex).ToList();
                int colorOfCurrentVertex = chromosomeValues[vertex - 1];
                hasAnyNeighborSameColor = hasAnyNeighborSameColor ||
                                          neighbors.Any(x => chromosomeValues[x - 1] == colorOfCurrentVertex);
                countOfBadColoring += neighbors.Count(x => chromosomeValues[x - 1] == colorOfCurrentVertex);
            }

            return !hasAnyNeighborSameColor;
        }

        private int GetNumberOfRequiredColors(int[] chromosomeValues)
        {
            return chromosomeValues.ToList().Distinct().Count();
        }
    }
}
