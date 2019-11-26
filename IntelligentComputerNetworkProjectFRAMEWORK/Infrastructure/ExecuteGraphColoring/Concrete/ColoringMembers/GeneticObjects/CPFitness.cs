using System;
using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete.ColoringMembers.GeneticObjects
{
    public class CPFitness : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {
            try
            {
                CPChromosome localChromosome = chromosome as CPChromosome;
                if(localChromosome == null) throw new InvalidProgramException("Chromosome cannot be null");
                int[] chromosomeValues = localChromosome.GetValues();
#if DEBUG
                string p = $"{chromosomeValues[0]} , {chromosomeValues[1]} , {chromosomeValues[2]} , {chromosomeValues[3]}";
#endif
                Graph graph = GraphProvider.Graph;

                bool hasAnyNeighborSameColor = false;
                double countOfBadColoring = 0;
                foreach (int vertex in graph.Vertexes)
                {
                    IList<int> neighbors = graph.NeighborsList(vertex).ToList();
                    int colorOfCurrentVertex = chromosomeValues[vertex - 1];
                    hasAnyNeighborSameColor = hasAnyNeighborSameColor ||
                                              neighbors.Any(x => chromosomeValues[x - 1] == colorOfCurrentVertex);
                    countOfBadColoring += (double)(neighbors.Count(x => chromosomeValues[x - 1] == colorOfCurrentVertex) -1) /
                                          neighbors.Count;
                }

                if (hasAnyNeighborSameColor)
                {
                    return -(countOfBadColoring + graph.Vertexes.Count+1);
                }

                return -(chromosomeValues.ToList().Distinct().Count());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return int.MinValue;
            }
        }
    }
}
