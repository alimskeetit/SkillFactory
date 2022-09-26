using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticum10._5._1
{
    internal class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }
}
