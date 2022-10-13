using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace SFLINQ;
class Program
{
    public static void Main()
    {
        // Словарь для хранения стран с городами
        var Countries = new Dictionary<string, List<City>>();

        // Добавим Россию с её городами
        var russianCities = new List<City>();
        russianCities.Add(new City("Москва", 11900000));
        russianCities.Add(new City("Санкт-Петербург", 4991000));
        russianCities.Add(new City("Волгоград", 1099000));
        russianCities.Add(new City("Казань", 1169000));
        russianCities.Add(new City("Севастополь", 449138));
        Countries.Add("Россия", russianCities);

        // Добавим Беларусь
        var belarusCities = new List<City>();
        belarusCities.Add(new City("Минск", 1200000));
        belarusCities.Add(new City("Витебск", 362466));
        belarusCities.Add(new City("Гродно", 368710));
        Countries.Add("Беларусь", belarusCities);

        // Добавим США
        var americanCities = new List<City>();
        americanCities.Add(new City("Нью-Йорк", 8399000));
        americanCities.Add(new City("Вашингтон", 705749));
        americanCities.Add(new City("Альбукерке", 560218));
        Countries.Add("США", americanCities);

        var cities = from country in Countries
                     from city in country.Value
                     where city.Population > 1000000
                     orderby city.Population descending
                     select city;

        foreach (var city in cities)
        {
            Console.WriteLine(city.Name + " " + city.Population);
        }

        string[] text = {   "Раз два три",
                            "четыре пять шесть",
                             "семь восемь девять" };

        var newText = from str in text
                      from word in str.Split(' ')
                      select word;

        foreach (var word in newText)
        {
            Console.WriteLine(word);
        }

        List<Student> students = new List<Student>
        {
           new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
           new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
           new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
           new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
        };

        // Составим запрос ()
        var selectedStudents = students.SelectMany(
            collectionSelector: s => s.Languages,
            resultSelector: (s, l) => new { Student = s, Lang = l })
            .Where(s => s.Lang == "английский" && s.Student.Age < 28)
            .Select(s => s.Student);

        // Выведем результат
        foreach (Student student in selectedStudents)
            Console.WriteLine($"{student.Name} - {student.Age}");

        var companies = new Dictionary<string, string[]>();

        companies.Add("Apple", new[] { "Mobile", "Desktop" });
        companies.Add("Samsung", new[] { "Mobile" });
        companies.Add("IBM", new[] { "Desktop" });

        var mobileCompanies = companies.Where(
            company => company.Value.Contains("Mobile"));

        foreach (var item in mobileCompanies)
        {
            Console.WriteLine(item.Key);
        }

        var numsList = new List<int[]>()
        {
           new[] {2, 3, 7, 1},
           new[] {45, 17, 88, 0},
           new[] {23, 32, 44, -6},
        };

        var orderNums = numsList
            .SelectMany(n => n)
            .OrderBy(n => n);

        string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

        var newWords = words.Select(word => new
        {
            word,
            length = word.Length
        }).OrderBy(a => a.length);

        foreach (var x in newWords)
        {
            Console.WriteLine(x);
        }

        var ancetsOfStudents = from student in students
                               where student.Age < 27
                               let yearOfBirth = DateTime.Now.Year - student.Age
                               select new
                               {
                                   student.Name,
                                   yearOfBirth
                               };

        foreach (var item in ancetsOfStudents)
        {
            Console.WriteLine(item);
        }

        var coarses = new List<Coarse>
        {
           new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
           new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
        };

        var SFStudents = from student in students
                         where student.Age < 29 && student.Languages.Contains("английский")
                         from coarse in coarses
                         where coarse.Name.Contains("C#")
                         let yearOfBirth = DateTime.Now.Year - student.Age
                         select new
                         {
                             student.Name,
                             yearOfBirth,
                             Coarse = coarse.Name
                         };

        foreach (var item in SFStudents)
        {
            Console.WriteLine(item);
        }

        var contacts = new List<Contact>()
        {
           new Contact() { Name = "Андрей", Phone = 7999945005 },
           new Contact() { Name = "Сергей", Phone = 799990455 },
           new Contact() { Name = "Иван", Phone = 79999675 },
           new Contact() { Name = "Игорь", Phone = 8884994 },
           new Contact() { Name = "Анна", Phone = 665565656 },
           new Contact() { Name = "Василий", Phone = 3434 }
        };

        //while (true)
        //{
        //    int keyChar = Convert.ToInt32(Console.ReadLine());
        //    Console.Clear();
        //    foreach (var item in contacts.Skip(2 * (keyChar - 1)).Take(2).Select(contact => new
        //    {
        //        Name = contact.Name,
        //        Phone = contact.Phone
        //    }))
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        Console.Clear();

        var cars = new List<Car>()
        {
           new Car("Suzuki", "JP"),
           new Car("Toyota", "JP"),
           new Car("Opel", "DE"),
           new Car("Kamaz", "RUS"),
           new Car("Lada", "RUS"),
           new Car("Lada", "RUS"),
           new Car("Honda", "JP"),
        };

        cars.RemoveAll(c => c.CountryCode == "JP");
        foreach (var car in cars)
        {
            Console.WriteLine(car.Manufacture);
        }
    }

    public class City
    {
        public City(string name, long population)
        {
            Name = name;
            Population = population;
        }

        public string Name { get; set; }
        public long Population { get; set; }
    }
}

internal class Car
{
    public string Manufacture;
    public string CountryCode;

    public Car(string v1, string v2)
    {
        Manufacture = v1;
        CountryCode = v2;
    }
}

internal class Contact
{
    public Contact()
    {
    }

    public string Name { get; set; }
    public long Phone { get; set; }
}

internal class Coarse
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
}