public class StandartAccount : Account
{
    public StandartAccount()
    {
        Type = "Обычный";
    }
    public override void CalculateInterest()
    {
        Interest = Balance * 0.4;

        if (Balance < 1000)
            Interest -= Balance * 0.2;

        if (Balance < 50000)
            Interest -= Balance * 0.4;
    }
}
