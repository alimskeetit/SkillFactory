using SFPatternBuilder;

class Program
{
    public static void Main()
    {
        Product product;

        Conveyor carConveyor = new CarConveyor();

        CarPlant carPlant = new CarPlant();

        carPlant.Construct(carConveyor);

        product = carConveyor.Product;

        product.Show();
    }
} 