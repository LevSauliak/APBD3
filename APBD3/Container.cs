namespace APBD3;

public abstract class Container
{
    static uint IDCounter = 0;

    // Saving memory with allocating string once for the class
    public virtual string Type => "A";
    public uint Height { get; set; }
    public uint TareWeight { get; set; }
    public string SerialNumber { get; }
    public uint CargoWeight { get; set; }
    public uint Depth { get; set; }
    public uint MaximumPayload { get; set; }

    public Container(uint tareWeight, uint maximumPayload, uint height, uint depth)
    {
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
        MaximumPayload = maximumPayload;
        SerialNumber = $"KON-{Type}-{IDCounter++}";
    }

    public uint TotalWeight()
    {
        return CargoWeight + TareWeight;
    }

    public virtual uint Unload()
    {
        uint cache = CargoWeight;
        CargoWeight = 0;
        return cache;
    }

    public virtual uint Load(uint mass)
    {
        if (CargoWeight + mass > MaximumPayload)
        {
            throw new OverfillException(mass, CargoWeight, MaximumPayload);
        }

        CargoWeight += mass;
        return CargoWeight;
    }

    public override string ToString()
    {
        return $"Container of type: {Type}\nSerial number: {SerialNumber}\nCargo weight: {CargoWeight}\nTare weight: {TareWeight}";
    }
}
