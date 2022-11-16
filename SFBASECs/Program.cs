internal class Program
{
    public static void Main(string[] args)
    {
        int iterator = 0;
        int[] array = { 1, 2, 3, 4, 5, 6 };
        var filter = array.Where(n => n > 3);
        Print(filter);
        var newFilter = filter.Select(_ => iterator++).ToArray();
        Print(newFilter);
        Console.WriteLine(newFilter.First());
    }

    static void Print(IEnumerable<int> arg)
    {
        foreach (int i in arg) Console.Write(i + " ");
        Console.WriteLine();
    }
}