using System;
using GeneticSharp.Domain.Chromosomes;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete.ColoringMembers.GeneticObjects
{
    public class CPChromosome : ChromosomeBase
    {
        private readonly int[] _geneValues;
        private readonly int _length;
        private int m_population;

        private int[] RandomizeGenes(int[] geneValues)
        {
            Random rnd = new Random();
            for (int i = 0; i<geneValues.Length;i++)
            {
                int vertexColor = rnd.Next(0, geneValues.Length);
                geneValues[i] = vertexColor;
            }
            return geneValues;
        }

        public CPChromosome(int length, int[] geneValues, int population = 0) : base(length)
        {
            _length = length;
            _geneValues = geneValues;
            m_population = population;
            CreateGenes();
        }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(_geneValues[geneIndex]);
        }

        public override IChromosome CreateNew()
        {
            int[] geneValues;
            if (m_population > 0)
            {
                geneValues = (int[])RandomizeGenes(_geneValues).Clone();
                m_population--;
            }
            else
            {
                geneValues = (int[])_geneValues.Clone();
            }
            return new CPChromosome(_length, geneValues, m_population);
        }

        public int[] GetValues()
        {
            return _geneValues;
        }
    }
}
