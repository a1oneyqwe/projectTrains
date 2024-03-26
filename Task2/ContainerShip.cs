using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class ContainerShip
    {
        public string name { get; }
        public double maxSpeed { get; }
        public int maxNumberOfContainers { get; }
        public double maxWeight { get; }
        public List<Container> containers { get; }

        public ContainerShip(string name, double maxSpeed, int maxContainerNum, double maxWeight)
        {
            name = name;
            maxSpeed = maxSpeed;
            maxNumberOfContainers = maxContainerNum;
            maxWeight = maxWeight;
            containers = new List<Container>();
        }

        public void LoadContainer(Container container)
        {
            if (containers.Count >= maxNumberOfContainers)
            {
                throw new InvalidOperationException("Ship's maximum container capacity reached.");
            }

            double totalWeight = containers.Sum(c => c.massOfCargo + c.weightOfTare);
            if (totalWeight + container.massOfCargo + container.weightOfTare > maxWeight)
            {
                throw new InvalidOperationException("Ship's maximum weight capacity reached.");
            }

            containers.Add(container);
        }

        public void UnloadContainer(Container container)
        {
            containers.Remove(container);
        }
        public void ReplaceContainer(string containerNumber, Container newContainer)
        {
            var containerToReplace = containers.FirstOrDefault(c => c.idNumber == containerNumber);
            if (containerToReplace != null)
            {
                containers.Remove(containerToReplace);
                LoadContainer(newContainer);
            }
        }
       

        

        

        public void PrintShipInfo()
        {
            Console.WriteLine("Ship Name: " + name);
            Console.WriteLine("Max Speed: " + maxSpeed);
            Console.WriteLine("Max Container Capacity: " + maxNumberOfContainers);
            Console.WriteLine("Max Weight Capacity: " + maxWeight);
            Console.WriteLine("Containers on the Ship:");
            foreach (var container in containers)
            {
                Console.WriteLine("Container: " + container.idNumber + ", Cargo Mass: " + container.massOfCargo + ", Height: " + container.height + ", Tare Weight: " + container.weightOfTare + ", Depth: " + container.depth);
            }
        }
    }
}
