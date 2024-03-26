namespace Task2
{
    public class GasContainer : Container, IHazardNotifier
    {
        private const double EmptyingRate = 0.05;
        public double InternalPressure { get; }

        public GasContainer(string containerSerial, double cargoWeight, double containerHeight, double containerTareWeight, double containerDepth, double maxLoadCapacity, double pressure)
            : base(containerSerial, cargoWeight, containerHeight, containerTareWeight, containerDepth, maxLoadCapacity)
        {
            InternalPressure = pressure;
        }

        public override void LoadCargo(double loadWeight)
        {
            if (loadWeight > maxPayload)
            {
                throw new OverfillException("The cargo's weight exceeds the container's maximum load capacity.");
            }

            if (massOfCargo + loadWeight > maxPayload)
            {
                throw new DangerousOperationException("Attempting to load cargo beyond the container's capacity.");
            }

            massOfCargo += loadWeight;
        }

        public override void EmptyCargo()
        {
            massOfCargo -= massOfCargo * EmptyingRate;
        }

        public void NotifyHazard(string containerID)
        {
            Console.WriteLine("Hazardous situation detected in container " + containerID);
        }
    }
}
