using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticumModule13
{
    internal class Task1
    {
        public static void Task()
        {
            string path = @"C:\Users\Ванч\Downloads\Text1.txt";
            string text = File.ReadAllText(path);
            var words = text.Split(new char[]
            {
                ' ', '\r', '\n'
            }, StringSplitOptions.RemoveEmptyEntries);
            
            List<string> list = new List<string>(words);

            LinkedList<string> linkedList = new LinkedList<string>(words);

            Stopwatch sw = new Stopwatch();

            Console.WriteLine("AddLast/Add:");
            string someText = "TEXT";
            
            Console.WriteLine("LinkedList<T>");
            
            sw.Restart();
            linkedList.AddLast(someText);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);

            Console.WriteLine("List<T>");
            sw.Restart();
            list.Add(someText);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            
            Console.WriteLine("Remove first element: ");
            
            Console.WriteLine("LinkedList<T>");
            sw.Restart();
            linkedList.Remove(words[0]);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            Console.WriteLine("List<T>");
            list.Remove(words[0]);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);


            Console.WriteLine("Remove last element: ");

            Console.WriteLine("LinkedList<T>");
            sw.Restart();
            linkedList.Remove(someText);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            Console.WriteLine("List<T>");
            list.Remove(someText);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }
    }
}
