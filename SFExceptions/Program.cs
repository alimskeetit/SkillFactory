using System;

namespace SFExceptionsAndDelegates
{
    class Program
    {
        public delegate void DelegateSub(int x, int y);

        public delegate string GreetingsDelegate(string name);

        public delegate void ShowMessageDelegate(string message);

        public delegate int Calculate(int a, int b);

        public static void Main()
        {

        }
        
        public static void FuncEx()
        {
            Exception exception = new Exception("Exception!!!!!!!");
            exception.Data.Add("Дата создания: ", DateTime.Now);
            exception.HelpLink = "www.google.com";

            try
            {
                throw new RankException();
            }
            catch (Exception ex) when (ex.Message == "Exception!!!!!!!")
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) when (ex is ArgumentNullException)
            {
                Console.WriteLine("ЭТО АРГУМЕНТНАЛЭКЗЕПШОН");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }

        public static void Method1()
        {
            try
            {
                throw new Exception("Внутреннее исключение");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Method2()
        {
            try
            {
                Method1();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Sub(int x, int y)
        {
            Console.WriteLine(x - y);
        }

        public static void Sum(int x, int y)
        {
            Console.WriteLine(x + y);
        }

        public static void FuncDelegate()
        {
            DelegateSub delegateSub = Sub;
            delegateSub += Sum;
            delegateSub(2, 1);
            delegateSub -= Sum;
            delegateSub(2, 1);
        }

        public static void FuncAnonymous()
        {
            GreetingsDelegate gd = delegate (string name)
            {
                return "Привет @" + name + " и добро пожаловать на SkillFactory!";
            };
            string GreetingsMessage = gd.Invoke("Pranaya");
            
            Console.WriteLine(GreetingsMessage);

            ShowMessageDelegate showMessageDelegate = (message) =>
            {
                Console.WriteLine(message);
            };

            showMessageDelegate("HEllo");

            Calculate calculate = (x, y) => x + y;
            
            Console.WriteLine(calculate(10, 40));
        }

        public static Car CreateCar()
        {
            return new Car();
        }
        
        public static Lexus CreateLexus()
        {
            return new Lexus();
        }

        public delegate Car CreateSomeCar();

        public static void GetParentInfo(Parent parent)
        {
            Console.WriteLine(parent.GetType());
        } 
        
        public delegate void Info(Child child);

        public static void FuncDelegatesAndCo()
        {
            CreateSomeCar create = CreateLexus;
            create += CreateCar;

            Info info = GetParentInfo;

        }
    }
    class MyException: Exception
    {
        public MyException()
        {

        }

        public MyException (string message) : base(message)
        {

        }
    }

    class Car { }
    class Lexus : Car { }

    class Parent { }
    class Child : Parent { }
}