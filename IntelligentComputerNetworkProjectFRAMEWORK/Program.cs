using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelligentComputerNetworkProjectFRAMEWORK.FileReading;
using IntelligentComputerNetworkProjectFRAMEWORK.GraphInterpretation;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK
{
    public class Program
    {
        private static void Main()
        {
            try
            {
                Console.WriteLine("Give the file path :");
                string path = Console.ReadLine();
                
                GraphInterpreter graphInterpreter = new GraphInterpreter(path);
                Graph graph = graphInterpreter.GetGraph;

                Console.WriteLine(graph.PrintGraphInOriginalForm());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
