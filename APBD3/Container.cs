namespace APBD3;

public abstract class Container
{
    static int Counter = 0;

    // Saving memory with allocating string once for the class
    public virtual string Type => "A";
    public int Height { get; set; }
    public int TareWeight { get; set; }

    public string SerialNumber { get; }

    public int CargoWeight { get; set; }

    public int Depth { get; set; }
    public int MaximumPayload { get; set; }

    public Container(int tareWeight, int maximumPayload, int height, int depth)
    {
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
        MaximumPayload = maximumPayload;
        SerialNumber = $"KON-{Type}-{Counter++}";
    }

    public virtual int empty()
    {
        int cache = CargoWeight;
        CargoWeight = 0;
        return cache;
    }

    public virtual int load(int mass)
    {
        if (CargoWeight + mass > MaximumPayload)
        {
            throw new OverfillException(mass, CargoWeight, MaximumPayload);
        }

        CargoWeight += mass;
        return CargoWeight;
    }
}

public class OverfillException : Exception
{
    public int input { get; }
    public int filled { get; }
    public int max { get; }

    public OverfillException(int input, int filled, int max) : base()
    {
        this.input = input;
        this.filled = filled;
    }

    public override string ToString()
    {
        return $"OverfillException: tried to fill {input} kg when already filled {filled} kg and max {max} kg.";
    }
}