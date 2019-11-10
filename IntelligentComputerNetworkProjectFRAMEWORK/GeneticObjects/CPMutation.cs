using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;
using IntelligentComputerNetworkProjectFRAMEWORK.StaticProvider;

namespace IntelligentComputerNetworkProjectFRAMEWORK.GeneticObjects
{
    public class CPMutation : MutationBase, IMutation
    {
        private readonly IRandomization m_rnd;

        public CPMutation()
        {
            m_rnd = RandomizationProvider.Current;
        }
        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            try
            {
                CPChromosome cpChromosome = chromosome as CPChromosome;
                double rand = m_rnd.GetDouble();
                if (!(rand <= probability)) return;

                //var i = m_rnd.GetInt(0, chromosome.Length);
                //var j = m_rnd.GetInt(0, chromosome.Length);
                //var v1 = cpChromosome.GetGene(i);
                //var v2 = cpChromosome.GetGene(j);
                //cpChromosome.ReplaceGene(i, v2);
                //cpChromosome.ReplaceGene(j, v1);

                int[] genes = cpChromosome.GetValues();

                Graph graph = GraphProvider.Graph;

                foreach (int vertex in graph.Vertexes)
                {
                    var p = graph.NeighborsList(vertex);
                    if (p.Any(z => genes[z - 1] == genes[vertex - 1]))
                        genes[vertex - 1] = m_rnd.GetInt(0, chromosome.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
