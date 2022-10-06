using System.Collections;
using System.Text;
using System.Collections.Generic;

namespace SFCollections;

class Program
{
    public static void Main()
    {
        //var array = Func1(new ArrayList() { 1, 2, "asd", "2", 3, "zxc" });
        //foreach (var item in array)
        //{
        //    Console.WriteLine(item);
        //}
        UniqueSymbols("Подсчитайте, сколько уникальных символов в этом предложении, используя HashSet<T>, учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.");

    }

    public static ArrayList Func1(ArrayList input)
    {
        int sum = 0;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in input)
        {
            if (item is int)
            {
                sum += (int)item;
            }
            if (item is string)
            {
                stringBuilder.Append(item);
            }
        }
        return new ArrayList() { sum, stringBuilder.ToString() };
    }

    public static void AddUnique(Contact contact, List<Contact> phoneBook)
    {
        bool alreadyExists = false;
        foreach (Contact item in phoneBook)
        {
            if (contact.Name == item.Name)
            {
                alreadyExists = true;
                break;
            }
        }
        if (!alreadyExists) phoneBook.Add(contact);
        phoneBook.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
        foreach (Contact item in phoneBook)
        {
            Console.WriteLine(item.Name + " " + item.PhoneNumber);
        }
    }

    public static void DoSmth(List<string> months, ArrayList array)
    {
        var temp = new string[7];
        temp = (string[])array.GetRange(4, 7).ToArray();
        months.AddRange(temp);
    }

    public static void UniqueSymbols(in string str)
    {
        HashSet<char> chars = new HashSet<char>();
        foreach (char ch in str)
        {
            chars.Add(ch);
        }

        Console.WriteLine(chars.Count);
    }

    public static bool HasNumbers(in string str)
    {
        HashSet<char> numbers = new HashSet<char>();
        for (int i = 0; i < 10; i++)
        {
            numbers.Add(Convert.ToChar(i));
        }

        HashSet<char> symbols = new HashSet<char>();
        foreach (char ch in str)
        {
            symbols.Add(ch);
        }

    
        if (symbols.Overlaps(numbers)) return true;
        return false;
    }

    public static int UniqueWithoutPunctuations(in string str)
    {
        HashSet<char> punctuations = new HashSet<char>()
        {
            '.', ',', ' '
        };

        HashSet<char> symbols = new HashSet<char>();
        foreach (char ch in str)
        {
            symbols.Add(ch);
        }
        symbols.ExceptWith(punctuations);
        return symbols.Count;
    }
}

public class Contact // модель класса
{
    public Contact(string name, long phoneNumber, String email) // метод-конструктор
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public String Name { get; }
    public long PhoneNumber { get; }
    public String Email { get; }
}