namespace Task2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private const double HazardousCargoCapacityPercentage = 0.5;
        private const double OrdinaryCargoCapacityPercentage = 0.9;
        private bool isHazardous;

        public LiquidContainer(string containerSerial, double loadWeight, double containerHeight, double containerTareWeight, double containerDepth, double maxLoadCapacity, bool isHazardous)
            : base(containerSerial, loadWeight, containerHeight, containerTareWeight, containerDepth, maxLoadCapacity)
        {
            this.isHazardous = isHazardous;
        }

        public override void LoadCargo(double loadWeight)
        {
            if (loadWeight > maxPayload)
            {
                throw new OverfillException("The cargo weight exceeds the container maximum load capacity.");
            }

            double maxCapacityPercentage = isHazardous ? HazardousCargoCapacityPercentage : OrdinaryCargoCapacityPercentage;

            if (massOfCargo + loadWeight > maxPayload * maxCapacityPercentage)
            {
                throw new DangerousOperationException("Attempting to load cargo beyond the container capacity.");
            }

            massOfCargo += loadWeight;
        }

        public override void EmptyCargo()
        {
            massOfCargo = 0;
        }

        public void NotifyHazard(string containerNumber)
        {
            Console.WriteLine("Hazardous situation detected in container " + containerNumber);
        }
    }
}
