using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticum10._5._1.Task2
{
    internal class Task2
    {
        public static void Task()
        {
            Calculator calculator = new Calculator(new Logger());
            try
            {
                Console.Write("Введите первое число: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Введите второе число: ");
                int b = int.Parse(Console.ReadLine());
                calculator.Logger.Event(Convert.ToString(calculator.Sum(a, b)));    
            }
            catch (FormatException ex)
            {
                calculator.Logger.Error(ex.Message);
            }
        }
    }
}
