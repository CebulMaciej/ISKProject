using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Concrete;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ExecuteGraphColoring.Response.Abstract;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.GraphInterpretation;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ShowInformation;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticConfiguration;
using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;
using IntelligentComputerNetworkProjectFRAMEWORK.Object.Const;
using System;

namespace IntelligentComputerNetworkProjectFRAMEWORK
{
    public class Startup
    {
        public void Run()
        {
            InfoDraftsman info = new InfoDraftsman();

            while (true)
            {
                info.DrawAppHeader();
                Console.WriteLine("*** MENU ***");
                Console.WriteLine("1 - Get default parameters -> fast start");
                Console.WriteLine("2 - Enter only important parameters");
                Console.WriteLine("3 - Enter all parameters");
                Console.WriteLine("9 - Exit");
                Console.Write("\tChoice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        StartWithDefaultParameters();
                        break;
                    case 2:
                        StartWithEnterRequiredParameters();
                        break;
                    case 3:
                        StartWithEnterAllParameters();
                        break;
                    default:
                        return;
                }
            }
        }

        private void StartWithDefaultParameters()
        {
            IColoringGraphExecutor coloringGraphExecutor = new ColoringGraphExecutor();
            InfoDraftsman info = new InfoDraftsman();

            ColorGraphParameters parameters = GetAllDefaultParameters();
            info.DrawAppHeader();
            InitGraph();
            info.DrawGraph();
            parameters.Draw();
            IGraphColoringResponse response = coloringGraphExecutor.ColorGraph(parameters);
            ShowResult(response);
            Console.WriteLine();
            Console.WriteLine("**Press any button to return to the menu**");
            Console.WriteLine();
            Console.ReadKey();
        }

        private void StartWithEnterRequiredParameters()
        {
            IColoringGraphExecutor coloringGraphExecutor = new ColoringGraphExecutor();
            InfoDraftsman info = new InfoDraftsman();

            ColorGraphParameters parameters = EnterOnlyRequiredParameters();
            info.DrawAppHeader();
            InitGraph();
            info.DrawGraph();
            parameters.Draw();
            IGraphColoringResponse response = coloringGraphExecutor.ColorGraph(parameters);
            ShowResult(response);
            Console.WriteLine();
            Console.WriteLine("**Press any button to return to the menu**");
            Console.WriteLine();
            Console.ReadKey();
        }

        private void StartWithEnterAllParameters()
        {
            IColoringGraphExecutor coloringGraphExecutor = new ColoringGraphExecutor();
            InfoDraftsman info = new InfoDraftsman();

            ColorGraphParameters parameters = EnterAllParameters();
            info.DrawAppHeader();
            InitGraph();
            info.DrawGraph();
            parameters.Draw();
            IGraphColoringResponse response = coloringGraphExecutor.ColorGraph(parameters);
            ShowResult(response);
            Console.WriteLine();
            Console.WriteLine("**Press any button to return to the menu**");
            Console.WriteLine();
            Console.ReadKey();
        }


        private ColorGraphParameters EnterAllParameters()
        {
            Console.WriteLine("--Enter all parameters--");
            Console.Write(Configuration.MinPopulationSizeLabel);
            int minPopulationSize = int.Parse(Console.ReadLine());

            Console.Write(Configuration.MaxPopulationSizeLabel);
            int maxPopulationSize = int.Parse(Console.ReadLine());

            Console.Write(Configuration.CrossoverProbabilityLabel);
            float crossoverProbability = float.Parse(Console.ReadLine());

            Console.Write(Configuration.MutationProbabilityLabel);
            float mutationProbability = float.Parse(Console.ReadLine());

            Console.Write(Configuration.MaxTimeLabel);
            TimeSpan maxTime = TimeSpan.FromMinutes(int.Parse(Console.ReadLine()));

            Console.Write(Configuration.MaxGenerationsLabel);
            int maxNumberOfGenerations = int.Parse(Console.ReadLine());

            Console.Write(Configuration.FitnessStagnationLabel);
            int fitnessStagnation = int.Parse(Console.ReadLine());

            Console.Write(Configuration.ExpectedFitnessLabel);
            double expectedFitness = double.Parse(Console.ReadLine());

            return new ColorGraphParameters(minPopulationSize, maxPopulationSize, SelectionType.Elite, CrossoverType.OnePoint, crossoverProbability, mutationProbability,
                maxTime, maxNumberOfGenerations, fitnessStagnation, -expectedFitness);
        }

        private ColorGraphParameters EnterOnlyRequiredParameters()
        {
            Console.WriteLine("--Enter required parameters--");
            Console.Write(Configuration.PopulationSizeLabel);
            int populationSize = int.Parse(Console.ReadLine());

            Console.Write(Configuration.MaxGenerationsLabel);
            int maxNumberOfGenerations = int.Parse(Console.ReadLine());

            Console.Write(Configuration.ExpectedFitnessLabel);
            double expectedFitness = double.Parse(Console.ReadLine());

            return new ColorGraphParameters(populationSize, maxNumberOfGenerations, expectedFitness);
        }

        private ColorGraphParameters GetAllDefaultParameters()
        {
            return new ColorGraphParameters();
        }

        private void InitGraph()
        {
            GraphInterpreter graphInterpreter = new GraphInterpreter();
            Graph graph = graphInterpreter.GetDefaultGraph();
            GraphProvider.SetGraph(graph);
        }


        private void ShowResult(IGraphColoringResponse response)
        {
            if (!response.Success)
            {
                Console.WriteLine("Not found correct coloring of given graph");
                return;
            }
            Console.WriteLine(response.ColoredGraph.PrintGraphColors());
        }
    }
}
