namespace Task2
{
    public class RefrigeratedContainer : Container
    {
        public string productType { get; }
        public double temperature { get; }

        public RefrigeratedContainer(string containerSerial, double loadWeight, double containerHeight, double containerTareWeight, double containerDepth, double maxLoadCapacity, string productKind, double storageTemperature)
            : base(containerSerial, loadWeight, containerHeight, containerTareWeight, containerDepth, maxLoadCapacity)
        {
            productType = productKind;
            temperature = storageTemperature;
        }

        public override void LoadCargo(double weight)
        {
            if (weight > maxPayload)
            {
                throw new OverfillException("weight exceeds container capacity");
            }

            if (massOfCargo + weight > maxPayload)
            {
                throw new DangerousOperationException("we cant load because of container capacity");
            }

            massOfCargo += weight;
        }

        public override void EmptyCargo()
        {
            massOfCargo = 0;
        }
    }
}
