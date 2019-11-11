using System;
using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;
using IntelligentComputerNetworkProjectFRAMEWORK.StaticProvider;

namespace IntelligentComputerNetworkProjectFRAMEWORK.GeneticObjects
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
                    IList<int> sameVertexGroup = graph.NeighborsList(vertex).ToList();
                    int firstVertexColor = chromosomeValues[vertex - 1];
                    hasAnyNeighborSameColor = hasAnyNeighborSameColor ||
                                              sameVertexGroup.Any(x => chromosomeValues[x - 1] == firstVertexColor);
                    countOfBadColoring += (double)(sameVertexGroup.Count(x => chromosomeValues[x - 1] == firstVertexColor)-1) /
                                          sameVertexGroup.Count;
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
