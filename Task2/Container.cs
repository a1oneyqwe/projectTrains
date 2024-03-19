namespace Task2
{
    public abstract class Container
    {
        public string SerialNumber { get; }
        public double CargoMass { get; protected set; }
        public double Height { get; }
        public double TareWeight { get; }
        public double Depth { get; }
        public double MaxPayload { get; }

        public Container(string serialNumber, double cargoMass, double height, double tareWeight, double depth, double maxPayload)
        {
            SerialNumber = serialNumber;
            CargoMass = cargoMass;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            MaxPayload = maxPayload;
        }

        public abstract void LoadCargo(double cargoMass);
        public abstract void EmptyCargo();
    }
}
