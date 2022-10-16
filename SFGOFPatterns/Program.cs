using System.Security.Principal;

class Program
{
    public static void Main()
    {
        Account account = new SalaryAccount();
        account.Interest = 2;
        account.Balance = 10000;
        account.CalculateInterest();
        Console.WriteLine(account.Balance + " " + account.Interest);

        account = new SalaryAccount();
        account.Interest = 3;
        account.Balance = 20000;
        account.CalculateInterest();
        Console.WriteLine(account.Balance + " " + account.Interest);

    }
}