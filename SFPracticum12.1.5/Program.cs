namespace SFPracticum12._1._5
{
    class Program
    {
        public static void Main()
        {
            User[] users =
            {
                new User ("asd", "Леха", true),
                new User("zxc", "Marco", false),
                new User("baby228", "John", false)
            };

            foreach (var x in users)
            {
                Console.WriteLine(x);
            }

            Console.Write("Введите логин: ");
            var login = Console.ReadLine();
            foreach (User x in users)
            {
                if (login == x.Login)
                {
                    if (!x.IsPremium) User.ShowAds();
                    Console.WriteLine("Добро пожаловать");
                }
            }
        }
    }

    class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }

        public override string ToString()
        {
            return $"Login: {Login}, Name: {Name}, Premium: " + (IsPremium ? "Activated" : "Disactivated") + " .\n";

        }
        public User(string login, string name, bool isPremium)
        {
            Login = login;
            Name = name;
            IsPremium = isPremium;
        }
        public static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
    }
}