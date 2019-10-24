using System.IO;

namespace IntelligentComputerNetworkProjectFRAMEWORK.FileReading
{
    public class FileReader
    {
        private readonly string _path;
        public FileReader(string path)
        {
            _path = path;
        }

        public string FileContent => File.ReadAllText(_path);
    }
}
