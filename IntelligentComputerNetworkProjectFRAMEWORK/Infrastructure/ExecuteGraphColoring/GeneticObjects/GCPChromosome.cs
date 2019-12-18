using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.GeneticObjects
{
    public class GCPChromosome : ChromosomeBase
    {
        private readonly int[] _geneValues;

        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly int _length;

        public GCPChromosome(int minValue, int maxValue, int length) 
            : this(minValue, maxValue, length, null) {  }

        public GCPChromosome(int minValue, int maxValue, int length, int[] geneValues) : base(length)
        {
            _length = length;
            _minValue = minValue;
            _maxValue = maxValue;
            _geneValues = geneValues;

            if (geneValues == null)
            {
                geneValues = new int[length];
                var rnd = RandomizationProvider.Current;

                for (int i = 0; i < geneValues.Length; i++)
                {
                    geneValues[i] = rnd.GetInt(minValue, maxValue);
                }
                _geneValues = geneValues;
            }
            CreateGenes();
        }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(_geneValues[geneIndex]);
        }

        public override IChromosome CreateNew()
        {
            return new GCPChromosome(_minValue, _maxValue, _length, _geneValues);
        }

        public int[] GetValues()
        {
            return _geneValues;
        }
    }
}
