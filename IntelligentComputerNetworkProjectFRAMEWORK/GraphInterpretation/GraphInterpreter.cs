using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using IntelligentComputerNetworkProjectFRAMEWORK.FileReading;
using IntelligentComputerNetworkProjectFRAMEWORK.Object;

namespace IntelligentComputerNetworkProjectFRAMEWORK.GraphInterpretation
{
    public class GraphInterpreter
    {
        private readonly string _fileContent;
        public GraphInterpreter(string filePath)
        {
            FileReader fileReader = new FileReader(filePath);
            _fileContent = fileReader.FileContent;
        }

        public Graph GetGraph => ReadGraphFromFileContent();

        private Graph ReadGraphFromFileContent()
        {
            IList<string> fileLines = _fileContent.Split(_fileSeparators,StringSplitOptions.RemoveEmptyEntries);

            int quantityOfEdges = ExtractEdgesQuantity(fileLines);

            IList<Edge> edges = new List<Edge>();
            for (int i = 1; i < fileLines.Count; i++)
            {
                IList<string> edgeElements = ExtractEdgeElement(fileLines, i);

                edges.Add(CreateEdgeFromElementsList(edgeElements));
            }
            return new Graph(quantityOfEdges,edges);
        }

        private static Edge CreateEdgeFromElementsList(IList<string> lineElement)
        {
            return new Edge(int.Parse(lineElement[0]), int.Parse(lineElement[1]), int.Parse(lineElement[2]));
        }

        private List<string> ExtractEdgeElement(IList<string> fileLines, int i)
        {
            return RemoveLastElement(fileLines[i].Split(_lineSeparator).ToList()).Select(x=> x.Substring(1)).ToList();
        }

        private int ExtractEdgesQuantity(IList<string> fileLines)
        {
            return int.Parse(fileLines[0].Split(_lineSeparator)[0].Substring(1));
        }

        private static IEnumerable<string> RemoveLastElement(IList<string> list)
        {
            list.RemoveAt(list.Count-1);
            return list;
        }

        private readonly string[] _fileSeparators = { "\r\n" };
        private readonly char _lineSeparator = '>';
    }
}
