using System;

namespace IntelligentComputerNetworkProjectFRAMEWORK
{
    public class Program
    { 
        private static void Main()
        {
            try
            {
                Startup startup = new Startup();
                startup.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }


    }
}
