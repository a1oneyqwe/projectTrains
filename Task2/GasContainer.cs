namespace Task2
{
    public class GasContainer : Container, IHazardNotifier
    {
        private const double EmptyingPercentage = 0.05;
        public double Pressure { get; }

        public GasContainer(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload, double pressure)
            : base(serialNumber, cargoMass, height, tareWeight, depth, maxPayload)
        {
            Pressure = pressure;
        }

        public override void LoadCargo(double cargoMass)
        {
            if (cargoMass > MaxPayload)
            {
                throw new OverfillException("Cargo mass exceeds container's maximum payload.");
            }

            if (CargoMass + cargoMass > MaxPayload)
            {
                throw new DangerousOperationException("Attempting to load cargo beyond capacity.");
            }

            CargoMass += cargoMass;
        }

        public override void EmptyCargo()
        {
            CargoMass -= CargoMass * EmptyingPercentage;
        }

        public void NotifyHazard(string containerNumber)
        {
            Console.WriteLine($"Hazardous situation detected in container {containerNumber}");
        }
    }
}
