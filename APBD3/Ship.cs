namespace APBD3;

public class Ship
{
    private List<Container> _containers;
    private uint _cargoWeight;
    
    public uint MaxSpeed { get; set; }
    public uint MaxContainers { get; set; }
    public uint MaxWeight { get; set; }

    public Ship()
    {
        _containers = new List<Container>();
        _cargoWeight = 0;
        MaxContainers = 0;
        MaxSpeed = 0;
        MaxWeight = 0;
    }

    public Ship(uint maxWeight, uint maxContainers, uint maxSpeed)
    {
        MaxWeight = maxWeight;
        MaxContainers = maxContainers;
        MaxSpeed = maxSpeed;
    }

    public void LoadContainer(Container container)
    {
        uint containerWeight = container.TotalWeight();
        if (_containers.Count == MaxContainers)
        {
            throw new OverfillException(1, MaxContainers, MaxContainers);
        } else if (_cargoWeight + containerWeight > MaxWeight)
        {
           throw new OverfillException(containerWeight, _cargoWeight, MaxWeight); 
        }
        _cargoWeight += containerWeight;
        _containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
           LoadContainer(container); 
        }
    }

    public bool RemoveContainer(Container container)
    {
        return _containers.Remove(container);
    }

    public bool ReplaceContainer(string serialNumber, Container container)
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].SerialNumber.Equals(serialNumber))
            {
                _containers[i] = container;
                return true;
            }
        }
        return false;
    }

    public void TransferContainer(Container container, Ship ship)
    {
        ship.LoadContainer(container);
        RemoveContainer(container);
    }

    public override string ToString()
    {
        return
            $"Ship\nCargo weight: {_cargoWeight}\nMax weight: {MaxWeight}\n Max container number: {MaxContainers}\n Max speed: {MaxSpeed}";
    }
    
}