using GeneticSharp.Domain.Terminations;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.GeneticTermination
{
    public class TerminationBuilder
    {
        public ITermination BuildTermination(ColorGraphParameters parameters)
        {
            return new OrTermination(
                new FitnessThresholdTermination(parameters.ExpectedFitness),
                new FitnessStagnationTermination(parameters.FitnessStagnationNumber),
                new GenerationNumberTermination(parameters.MaxNumberOfGenerations),
                new TimeEvolvingTermination(parameters.MaxEvolvingTime));
        }
    }
}
