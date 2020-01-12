using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticProvider;
using System;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.ShowInformation
{
    public class InfoDraftsman
    {
        public void DrawAppHeader()
        {
            Console.Clear();
            Console.WriteLine("(GCP) Graph coloring problem - genetic solution");
            Console.WriteLine();
        }

        public void DrawGraph()
        {
            Console.WriteLine();
            Console.WriteLine("--Graph form--");
            Console.WriteLine(GraphProvider.Graph.PrintGraphInOriginalForm());
        }

        public void ClearConsoleLines(int[] lineNumbers)
        {
            foreach (var lineNumber in lineNumbers)
            {
                int currentLineCursor = lineNumber;
                Console.SetCursorPosition(0, lineNumber);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
        }
    }
}
