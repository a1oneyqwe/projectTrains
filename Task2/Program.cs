using Task2;

public class Program
{
    static void Main(string[] args)
    {
        // Sample usage of the container loading management system
        try
        {
            LiquidContainer liquidContainer = new LiquidContainer("KON-L-1", 100, 100, 100, 100, 100000, true);
            liquidContainer.LoadCargo(10);
            Console.WriteLine($"Loaded cargo mass: {liquidContainer.CargoMass}");

            ContainerShip ship = new ContainerShip("Ship1", 100000, 1000000, 100000);
            ship.LoadContainer(liquidContainer);
            Console.WriteLine($"Number of containers on ship: {ship.Containers.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}