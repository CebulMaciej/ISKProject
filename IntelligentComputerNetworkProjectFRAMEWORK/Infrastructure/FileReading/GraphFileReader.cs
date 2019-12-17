using IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.StaticConfiguration;
using System;
using System.IO;

namespace IntelligentComputerNetworkProjectFRAMEWORK.Infrastructure.FileReading
{
    public class GraphFileReader
    {
        private readonly string _graphsDirectoryPath;
        public GraphFileReader()
        {
            _graphsDirectoryPath = PrepareGraphsDirectoryPath();
        }


        public string GetGraphFileContent(string graphFileName)
        {
            string graphPath = Path.Combine(_graphsDirectoryPath, graphFileName);
            if (!File.Exists(graphPath))
            {
                throw new FileNotFoundException(graphFileName);
            }

            return File.ReadAllText(graphPath);
        }

        public string GetDefaultGraphFileContent()
        {
            string graphPath = Path.Combine(_graphsDirectoryPath, Configuration.DefaultGraphFile);
            if (!File.Exists(graphPath))
            {
                throw new FileNotFoundException(Configuration.DefaultGraphFile);
            }

            return File.ReadAllText(graphPath);
        }

        private string PrepareGraphsDirectoryPath()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            return Path.Combine(projectDirectory, Configuration.GraphsDirectory);
        }
    }
}
