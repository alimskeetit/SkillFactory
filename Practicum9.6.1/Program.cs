using System;

namespace Practicum9._6._1
{
    class Program
    {
        public static void Task1()
        {
            Exception[] exceptions = new Exception[5];
            exceptions[0] = new ArgumentException();
            exceptions[1] = new ArgumentOutOfRangeException();
            exceptions[2] = new IndexOutOfRangeException();
            exceptions[3] = new TimeoutException();
            exceptions[4] = new MyException("Это мое собственное исключение");
            foreach (Exception exception in exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (MyException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Это {e.Message}");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Это {e.Message}");
                }
                catch (TimeoutException e)
                {
                    Console.WriteLine($"Это {e.Message}");
                }
                finally
                {
                    Console.WriteLine("Блок finally...");
                }
            }
        }

        public static void Task2()
        {
            string[] people = new string[5];
            for (int i = 0; i < people.Length; i++)
            {
                Console.Write("Введите фамилию: ");
                people[i] = Console.ReadLine();
            }

            NumberEnteredEvent += SetSort;
            while (true)
            {
                try
                {
                    Read();
                    break;
                }
                catch (MyException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            BubbleSort(people);
            foreach (string human in people)
            {
                Console.WriteLine(human);
            }
        }

        public static void Main()
        {
            Task1();
            Task2();
        }

        static int howSort;
        public static void SetSort(int number)
        {
            howSort = number;
        }

        public delegate void NumberEnteredDelegate(int number);
        public static event NumberEnteredDelegate NumberEnteredEvent;

        public static void Read()
        {
            Console.WriteLine("Введите 1 - сортировка [А-Я], 2 - сортировка [Я-А]");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2)
                throw new MyException("Введено некорректноке значение");

            NumberEntered(number);
        }

        public static void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="Exception"></exception>
        public static void BubbleSort(string[] array)
        {
            Func<string, string, bool> func;

            switch (howSort)
            {
                case 1:
                    func = LessThan;
                    break;
                case 2:
                    func = MoreThan;
                    break;
                default:
                    throw new Exception();
                    break;
            }

            string temp;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    if (func(array[j], array[j + 1]))
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
        }

        /// <summary>
        /// Функция сравнивает больше ли строка а строки b
        /// </summary>
        /// <param name="a">Первая строка</param>
        /// <param name="b">Вторая строка</param>
        /// <returns></returns>
        public static bool LessThan(string a, string b)
        {
            int minLength = a.Length > b.Length ? b.Length : a.Length;
            for (int i = 0; i < minLength; ++i)
            {
                if (a[i] < b[i]) return false;
                else if (a[i] > b[i]) return true;
            }

            return a.Length == minLength ? false : true;
        }

        /// <summary>
        /// Обратная LessThan
        /// </summary>
        /// <param name="a">Первая строка</param>
        /// <param name="b">Вторая строка</param>
        /// <returns></returns>
        public static bool MoreThan(string a, string b)
        {
            return !LessThan(a, b);
        }


    }

    class MyException : Exception
    {
        public MyException()
        {

        }
        public MyException(string message) : base(message)
        {
        }
    }
}