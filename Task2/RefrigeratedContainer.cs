namespace Task2
{
    public class RefrigeratedContainer : Container
    {
        public string ProductType { get; }
        public double Temperature { get; }

        public RefrigeratedContainer(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload, string productType, double temperature)
            : base(serialNumber, cargoMass, height, tareWeight, depth, maxPayload)
        {
            ProductType = productType;
            Temperature = temperature;
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
            CargoMass = 0;
        }
    }
}
