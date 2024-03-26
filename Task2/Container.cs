public abstract class Container
{
    public string idNumber { get; }
    public double massOfCargo { get; protected set; }
    public double height { get; }
    public double weightOfTare { get; }
    public double depth { get; }
    public double maxPayload { get; }

    public Container(string serialNumber, double massOfCargo, double height, double tareWeight, double depth, double maxPayload)
    {
        idNumber = serialNumber;
        massOfCargo = massOfCargo;
        height = height;
        weightOfTare = tareWeight;
        depth = depth;
        maxPayload = maxPayload;
    }

    public abstract void LoadCargo(double massOfCargo);
    public abstract void EmptyCargo();
}
