using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FindTheDistance.CommonIO;

namespace FindTheDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main entry point for the Console app
            var app = new LocationDisplay();
            try
            {
                app.DisplayToConsole();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
