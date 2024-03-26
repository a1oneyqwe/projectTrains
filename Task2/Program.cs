
using Task2;

public class Program
{
    static List<ContainerShip> containerShips = new List<ContainerShip>();
    static List<Container> containers = new List<Container>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("All ships:");
            DisplayContainerShips();
            Console.WriteLine("All containers on the ship:");
            DisplayContainers();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add ship");
            Console.WriteLine("2. Remove ship");
            Console.WriteLine("3. Add a container to the ship");
            Console.WriteLine("4. Replace a container on the ship");
            Console.WriteLine("5. Unload a container from the ship");
            Console.WriteLine("6. Load a container to the ship");
            Console.WriteLine("7. Print ship information");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddShip();
                    break;
                case "2":
                    RemoveShip();
                    break;
                case "3":
                    AddContainer();
                    break;
                case "4":
                     ReplaceContainerOnShip();
                    break;
                case "5":
                    UnloadContainerFromShip();
                    break;
                case "6":
                    LoadContainerOntoShip();
                    break;
                case "7":
                    PrintShipInformation();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void AddShip()
    {
        Console.Write("Enter ship name: ");
        string name = Console.ReadLine();
        Console.Write("Enter max speed: ");
        double speed = double.Parse(Console.ReadLine());
        Console.Write("Enter max container number: ");
        int maxContainerNum = int.Parse(Console.ReadLine());
        Console.Write("Enter max weight: ");
        double maxWeight = double.Parse(Console.ReadLine());

        containerShips.Add(new ContainerShip(name, speed, maxContainerNum, maxWeight));
    }
    static void DisplayContainers()
    {
        if (containers.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            foreach (var container in containers)
            {
                Console.WriteLine("Container: " + container.idNumber + " (CargoMass: " + container.massOfCargo + ", Height: " + container.height + ", TareWeight: " + container.weightOfTare + ", Depth: " + container.depth + ")");
            }
        }
    }
    static void DisplayContainerShips()
    {
        if (containerShips.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            foreach (var ship in containerShips)
            {
                Console.WriteLine("Ship: " + ship.name + ", Speed: " + ship.maxSpeed + ", MaxContainerNum: " + ship.maxNumberOfContainers + ", MaxWeight: " + ship.maxWeight);
            }
        }
    }

    
 static void RemoveShip()
    {
        Console.Write("Enter the name of the ship to remove: ");
        string name = Console.ReadLine();

        ContainerShip shipToRemove = containerShips.Find(s => s.name == name);
        if (shipToRemove != null)
        {
            containerShips.Remove(shipToRemove);
            Console.WriteLine("Ship removed successfully.");
        }
        else
        {
            Console.WriteLine("Ship not found.");
        }
    }
    

   

    static void AddContainer()
    {
        Console.Write("Enter container type (L for Liquid, G for Gas, C for Refrigerated): ");
        char containerType = Console.ReadLine().ToUpper()[0];

        Console.Write("Enter container serial number: ");
        string serialNumber = Console.ReadLine();
        Console.Write("Enter cargo mass: ");
        double cargoMass = double.Parse(Console.ReadLine());
        Console.Write("Enter height: ");
        double height = double.Parse(Console.ReadLine());
        Console.Write("Enter tare weight: ");
        double tareWeight = double.Parse(Console.ReadLine());
        Console.Write("Enter depth: ");
        double depth = double.Parse(Console.ReadLine());
        Console.Write("Enter max payload: ");
        double maxPayload = double.Parse(Console.ReadLine());

        Container container;
        switch (containerType)
        {
            case 'L':
                container = new LiquidContainer(serialNumber, cargoMass, height, tareWeight, depth, maxPayload, true);
                break;
            case 'G':
                container = new GasContainer(serialNumber, cargoMass, height, tareWeight, depth, maxPayload, 2);
                break;
            case 'C':
                Console.Write("Enter product type: ");
                string productType = Console.ReadLine();
                Console.Write("Enter temperature: ");
                double temperature = double.Parse(Console.ReadLine());
                container = new RefrigeratedContainer(serialNumber, cargoMass, height, tareWeight, depth, maxPayload, productType, temperature);
                break;
            default:
                Console.WriteLine("Invalid container type.");
                return;
        }

        containers.Add(container);
    }

    static void LoadContainerOntoShip()
    {
        Console.Write("Enter ship name: ");
        string shipName = Console.ReadLine();
        Console.Write("Enter container serial number: ");
        string containerSerialNumber = Console.ReadLine();

        ContainerShip ship = containerShips.Find(s => s.name == shipName);
        Container container = containers.Find(c => c.idNumber == containerSerialNumber);

        if (ship != null && container != null)
        {
            try
            {
                ship.LoadContainer(container);
                Console.WriteLine("Container loaded onto ship successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Ship or container not found.");
        }
    }
    static void ReplaceContainerOnShip()
    {
        Console.Write("Enter ship name: ");
        string shipName = Console.ReadLine();
        Console.Write("Enter container serial number to replace: ");
        string containerSerialNumber = Console.ReadLine();
        Console.WriteLine("Enter details for the new container:");

        AddContainer();

        ContainerShip ship = containerShips.Find(s => s.name == shipName);
        Container containerToRemove = containers.Find(c => c.idNumber == containerSerialNumber);
        Container newContainer = containers.Last();

        if (ship != null && containerToRemove != null && newContainer != null)
        {
            try
            {
                ship.ReplaceContainer(containerSerialNumber, newContainer);
                Console.WriteLine("Container replaced on the ship successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Ship, container to replace, or new container not found.");
        }
    }
    static void UnloadContainerFromShip()
    {
        Console.Write("Enter ship name: ");
        string shipName = Console.ReadLine();
        Console.Write("Enter container serial number: ");
        string containerSerialNumber = Console.ReadLine();

        ContainerShip ship = containerShips.Find(s => s.name == shipName);
        Container container = containers.Find(c => c.idNumber == containerSerialNumber);

        if (ship != null && container != null)
        {
            try
            {
                ship.UnloadContainer(container);
                Console.WriteLine("Container unloaded from ship successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Ship or container not found.");
        }
    }

    
        static void PrintShipInformation()
        {
            Console.Write("Enter ship name: ");
            string shipName = Console.ReadLine();

            ContainerShip ship = containerShips.Find(s => s.name == shipName);
            if (ship != null)
            {
                ship.PrintShipInfo();
            }
            else
            {
                Console.WriteLine("Ship not found.");
            }
       

    }
}