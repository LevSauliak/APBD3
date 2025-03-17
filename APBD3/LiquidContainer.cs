namespace APBD3;

public class LiquidContainer: Container, IHazardNotifier
{
    public override string Type => "L";
    
    public bool IsHazardous { get; set; }

    public LiquidContainer(int tareWeight, int maximumPayload, int height, int depth, bool isHazardous = false) : base(tareWeight, maximumPayload, height,
        depth)
    {
        isHazardous = isHazardous;
    }

    public void Notify()
    {
        Console.WriteLine($"Container {SerialNumber} is in Hazardous situation");
    }

    public override int load(int mass)
    {
        int max = IsHazardous ? MaximumPayload / 2: (int)(MaximumPayload * 0.9);
        if (mass + CargoWeight > max)
        {
            Notify();
            throw new OverfillException(mass, CargoWeight, max);
        }
        else
        {
           base.load(mass); 
        }

        return CargoWeight;
    }
}