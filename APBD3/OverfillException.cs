namespace APBD3;
public class OverfillException : Exception
{
    public OverfillException(uint input, uint filled, uint max) : base($"OverfillException: tried to fill {input} kg when already filled {filled} kg and max {max} kg.")
    {
    }
}
