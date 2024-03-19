namespace Task2
{
    public class ContainerShip
    {
        public string Name { get; }
        public double MaxSpeed { get; }
        public int MaxContainerNum { get; }
        public double MaxWeight { get; }
        public List<Container> Containers { get; }

        public ContainerShip(string name, double maxSpeed, int maxContainerNum, double maxWeight)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            MaxContainerNum = maxContainerNum;
            MaxWeight = maxWeight;
            Containers = new List<Container>();
        }

        public void LoadContainer(Container container)
        {
            if (Containers.Count >= MaxContainerNum)
            {
                throw new Exception("Ship's maximum container capacity reached.");
            }

            double totalWeight = Containers.Sum(c => c.CargoMass + c.TareWeight);
            if (totalWeight + container.CargoMass + container.TareWeight > MaxWeight)
            {
                throw new Exception("Ship's maximum weight capacity reached.");
            }

            Containers.Add(container);
        }

        public void UnloadContainer(Container container)
        {
            Containers.Remove(container);
        }
    }
}
