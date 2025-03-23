namespace APBD3;
public class OverfillException : Exception
{
    public uint Input { get; }
    public uint Filled { get; }
    public uint Max { get; }

    public OverfillException(uint input, uint filled, uint max) : base()
    {
        this.Input = input;
        this.Filled = filled;
        this.Max = max;
    }

    public override string ToString()
    {
        return $"OverfillException: tried to fill {Input} kg when already filled {Filled} kg and max {Max} kg.";
    }
}
