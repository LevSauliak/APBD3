namespace APBD3;

public class GasContainer: LiquidContainer, IHazardNotifier
{
    public override string Type => "G";

    public float Pressure { get; set; }

    public GasContainer(int tareWeight, int maximumPayload, int height, int depth, bool isHazardous=false) : base(tareWeight, maximumPayload,
        height, depth, isHazardous)
    { }

    public override int empty()
    {
        int to_empty = (int) (CargoWeight * 0.95);
        
        CargoWeight -= to_empty;

        return to_empty;
    }
}