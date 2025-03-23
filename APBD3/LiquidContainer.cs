namespace APBD3;

public class LiquidContainer: Container, IHazardNotifier
{
    public override string Type => "L";
    
    public bool IsHazardous { get; set; }

    public LiquidContainer(uint tareWeight, uint maximumPayload, uint height, uint depth, bool isHazardous = false) : base(tareWeight, maximumPayload, height,
        depth)
    {
        isHazardous = isHazardous;
    }

    public void Notify()
    {
        Console.WriteLine($"Container {SerialNumber} is in Hazardous situation");
    }

    public override uint Load(uint mass)
    {
        uint max = IsHazardous ? MaximumPayload / 2: (uint)(MaximumPayload * 0.9);
        if (mass + CargoWeight > max)
        {
            Notify();
            throw new OverfillException(mass, CargoWeight, max);
        }
        else
        {
           base.Load(mass); 
        }

        return CargoWeight;
    }
}