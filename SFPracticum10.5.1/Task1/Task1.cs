using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticum10._5._1.Task1
{
    internal class Task1
    {
        public static void Task()
        {
            Calculator calculator = new Calculator();
            try
            {
                Console.Write("Введите первое число: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Введите второе число: ");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine(calculator.Sum(a, b));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
