using IntelligentComputerNetworkProjectFRAMEWORK.Object.Const;
using System;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Object
{
    public class ColorGraphParameters
    {
        public ColorGraphParameters(int minPopulationSize, int maxPopulationSize, int maxNumberOfGenerations, 
            SelectionType selectionType, CrossoverType crossoverType, TimeSpan maxEvolvingTime)
        {
            MinPopulationSize = minPopulationSize;
            MaxPopulationSize = maxPopulationSize;
            MaxNumberOfGenerations = maxNumberOfGenerations;
            SelectionType = selectionType;
            CrossoverType = crossoverType;
            MaxEvolvingTime = maxEvolvingTime;
        }
        public int MinPopulationSize { get; }
        public int MaxPopulationSize { get; }
        public int MaxNumberOfGenerations { get; }
        public SelectionType SelectionType { get; }
        public CrossoverType CrossoverType { get; }
        public TimeSpan MaxEvolvingTime { get; }
    }
}
