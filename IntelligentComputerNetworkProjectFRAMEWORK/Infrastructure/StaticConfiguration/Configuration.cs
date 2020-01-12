using System;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticConfiguration
{
    public static class Configuration
    {
        public const string DefaultGraphFile = "default.txt";
        public const string GraphsDirectory = "data";

        public const string PopulationSizeLabel = "Population size: ";
        public const string MinPopulationSizeLabel = "Min population size: ";
        public const string MaxPopulationSizeLabel = "Max population size: ";
        public const string MaxGenerationsLabel = "Max number of generations: ";
        public const string CrossoverProbabilityLabel = "Crossover probability: ";
        public const string MutationProbabilityLabel = "Mutation probability: ";
        public const string MaxTimeLabel = "Max evolving time [minutes]: ";
        public const string FitnessStagnationLabel = "Max number of generation with fitness stagnation: ";
        public const string ExpectedFitnessLabel = "Min number of colors: ";

        public const float DefaultCrossoverProbability = 0.75f;
        public const float DefaultMutationProbability = 0.1f;
        public const int DefaultPopulationSize = 20;
        public const int DefaultMaxTimeMinutes = 5;
        public const int DefaultMaxGenerations = 10000;
        public const int DefaultFitnessStagnation = 10000;
        public const double DefaultExpectedFitness = 2;
    }
}
