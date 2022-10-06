namespace Program;
class Program
{

    public static void Main()
    {
        string path = @"C:\Users\Ванч\Downloads\cdev_Text.txt";

        string text = File.ReadAllText(path);
        char[] delimetrs = new char[] { ' ', '\n', '\r' };
        var words = text.Split(delimetrs, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(words.Length);

        Stack<int> numbers = new Stack<int>();
        
    }
}
