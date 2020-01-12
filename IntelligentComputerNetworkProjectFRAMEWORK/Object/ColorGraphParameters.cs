using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticConfiguration;
using IntelligentComputerNetworkProjectFRAMEWORK.Object.Const;
using System;
using System.Text;

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

        public ColorGraphParameters(int populationSize, int maxGenerations, double expectedFitness)
        {
            MinPopulationSize = populationSize;
            MaxPopulationSize = populationSize;
            MaxNumberOfGenerations = maxGenerations;
            SelectionType = SelectionType.Elite;
            CrossoverType = CrossoverType.OnePoint;
            CrossoverProbability = Configuration.DefaultCrossoverProbability;
            MutationProbability = Configuration.DefaultMutationProbability;
            MaxEvolvingTime = TimeSpan.FromMinutes(Configuration.DefaultMaxTimeMinutes);
            FitnessStagnationNumber = Configuration.DefaultFitnessStagnation;
            ExpectedFitness = -expectedFitness;
        }

        public ColorGraphParameters()
        {
            MinPopulationSize = Configuration.DefaultPopulationSize;
            MaxPopulationSize = Configuration.DefaultPopulationSize;
            MaxNumberOfGenerations = Configuration.DefaultMaxGenerations;
            SelectionType = SelectionType.Elite;
            CrossoverType = CrossoverType.OnePoint;
            CrossoverProbability = Configuration.DefaultCrossoverProbability;
            MutationProbability = Configuration.DefaultMutationProbability;
            MaxEvolvingTime = TimeSpan.FromMinutes(Configuration.DefaultMaxTimeMinutes);
            FitnessStagnationNumber = Configuration.DefaultFitnessStagnation;
            ExpectedFitness = -Configuration.DefaultExpectedFitness;
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

        public void Draw()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("--Selected parameters--");
            builder.AppendLine(Configuration.MinPopulationSizeLabel + MinPopulationSize);
            builder.AppendLine(Configuration.MaxPopulationSizeLabel + MaxPopulationSize);
            builder.AppendLine(Configuration.CrossoverProbabilityLabel + CrossoverProbability);
            builder.AppendLine(Configuration.MutationProbabilityLabel + MutationProbability);
            builder.AppendLine(Configuration.MaxTimeLabel + MaxEvolvingTime.TotalMinutes);
            builder.AppendLine(Configuration.MaxGenerationsLabel + MaxNumberOfGenerations);
            builder.AppendLine(Configuration.FitnessStagnationLabel + FitnessStagnationNumber);
            builder.AppendLine(Configuration.ExpectedFitnessLabel + -ExpectedFitness);
            Console.WriteLine(builder.ToString());
        }
    }
}
