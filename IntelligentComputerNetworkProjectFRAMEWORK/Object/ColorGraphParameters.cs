using IntelligentComputerNetworkProjectFRAMEWORK.Object.Const;
using System;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Object
{
    public class ColorGraphParameters
    {
        public ColorGraphParameters(int minPopulationSize, int maxPopulationSize, SelectionType selectionType, CrossoverType crossoverType, float crossoverProbability,
            float mutationProbability, TimeSpan maxEvolvingTime, int maxNumberOfGenerations, int fitnessStagnationNumber, double expectedFitness)
        {
            MinPopulationSize = minPopulationSize;
            MaxPopulationSize = maxPopulationSize;
            MaxNumberOfGenerations = maxNumberOfGenerations;
            SelectionType = selectionType;
            CrossoverType = crossoverType;
            CrossoverProbability = crossoverProbability;
            MutationProbability = mutationProbability;
            MaxEvolvingTime = maxEvolvingTime;
            FitnessStagnationNumber = fitnessStagnationNumber;
            ExpectedFitness = expectedFitness;
        }
        public int MinPopulationSize { get; }
        public int MaxPopulationSize { get; }
        public SelectionType SelectionType { get; }
        public CrossoverType CrossoverType { get; }

        public float CrossoverProbability { get; }
        public float MutationProbability { get; }

        public TimeSpan MaxEvolvingTime { get; }
        public int MaxNumberOfGenerations { get; }
        public int FitnessStagnationNumber { get; }
        public double ExpectedFitness { get; }
    }
}
