class Program
{
    /// <summary>
    ///  Клиентский код
    /// </summary>
    static void Main()
    {
        BaseClass myObject = new ImplementationOne(1);
        Console.WriteLine(myObject.GetId());

        BaseClass clone = myObject.Clone();
        Console.WriteLine(clone.GetId());

        myObject = new ImplementationTwo(2);
        Console.WriteLine(myObject.GetId());

        clone = myObject.Clone();
        Console.WriteLine(clone.GetId());
    }
}