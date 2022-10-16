public class SalaryAccount : Account
{
    public SalaryAccount()
    {
        Type = "Зарплатный";
    }

    public override void CalculateInterest()
    {
        Interest = Balance * 0.5;
    }
}
