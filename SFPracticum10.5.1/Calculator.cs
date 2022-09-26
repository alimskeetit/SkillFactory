using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticum10._5._1
{
    internal class Calculator : ICalculate
    {
        public Logger Logger { get; }

        public Calculator()
        {

        }

        public Calculator(Logger logger)
        {
            Logger = logger;
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
