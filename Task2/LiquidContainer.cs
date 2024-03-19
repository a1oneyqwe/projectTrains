namespace Task2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private const double HazardousCargoCapacityRatio = 0.5;
        private const double OrdinaryCargoCapacityRatio = 0.9;
        private bool isHazardous;

        public LiquidContainer(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload, bool isHazardous)
            : base(serialNumber, cargoMass, height, tareWeight, depth, maxPayload)
        {
            this.isHazardous = isHazardous;
        }

        public override void LoadCargo(double cargoMass)
        {
            if (cargoMass > MaxPayload)
            {
                throw new OverfillException("Cargo mass exceeds container's maximum payload.");
            }

            double maxCapacityRatio = isHazardous ? HazardousCargoCapacityRatio : OrdinaryCargoCapacityRatio;

            if (CargoMass + cargoMass > MaxPayload * maxCapacityRatio)
            {
                throw new DangerousOperationException("Attempting to load dangerous cargo beyond capacity.");
            }

            CargoMass += cargoMass;
        }

        public override void EmptyCargo()
        {
            CargoMass = 0;
        }

        public void NotifyHazard(string containerNumber)
        {
            Console.WriteLine($"Hazardous situation detected in container {containerNumber}");
        }
    }
}
