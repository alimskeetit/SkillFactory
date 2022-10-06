using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPracticumModule13
{
    internal class Task2
    {
        public static void Task()
        {
            string path = @"C:\Users\Ванч\Downloads\Text1.txt";
            string text = File.ReadAllText(path);

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            
            var words = text.Split(new char[]
            {
                ' ', '\r', '\n'
            }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> famous = new Dictionary<string, int>();
            //если строка была довалена в словарь, то инкремент счетчика
            //если нет, то добавляем в словарь
            foreach (string str in words)
            {
                if (famous.ContainsKey(str))
                {
                    ++famous[str];
                }
                else
                {
                    famous.Add(str, 1);
                }
            }

            SortedDictionary<int, string> sortedFamous = new SortedDictionary<int, string>();
            //если такое количество повторений встерчалось, то делаем конкатенацию Value и нового слова
            //если нет, то добавляем в словарь
            foreach (var item in famous)
            {
                if (sortedFamous.ContainsKey(item.Value))
                {
                    sortedFamous[item.Value] += $"\n{item.Key}";
                }
                else
                {
                    sortedFamous.Add(item.Value, item.Key);
                }
            }
            
            //переворачиваем словарь для того, чтобы словарь шел по убыванию значений
            var sortedDescend = sortedFamous.Reverse();

            int i = 0;
            foreach (var item in sortedDescend)
            {
                Console.WriteLine(item.Value);
                i++;
                if (i == 10) break;
            }
        }
    }
}
