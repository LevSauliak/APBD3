namespace APBD3;

public class GasContainer: LiquidContainer 
{
    public override string Type => "G";

    public float Pressure { get; set; }

    public GasContainer(uint tareWeight, uint maximumPayload, uint height, uint depth, bool isHazardous=false) : base(tareWeight, maximumPayload,
        height, depth, isHazardous)
    { }

    public override uint Unload()
    {
        uint toEmpty = (uint) (CargoWeight * 0.95);
        
        CargoWeight -= toEmpty;

        return toEmpty;
    }
}