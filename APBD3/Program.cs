// See https://aka.ms/new-console-template for more information

using APBD3;

static void TryCatch(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }
    }

uint tareWeight = 500;
uint cargoWeight = 3000;
uint depth = 20;
uint height = 10;
uint maximumPayload = 4000;

Container liquid1 = new LiquidContainer(tareWeight, maximumPayload, height, depth);
liquid1.Load(cargoWeight);
Container liquid2 = new LiquidContainer(tareWeight, maximumPayload, height, depth);
liquid2.Load(500);
Container gas1 = new GasContainer(tareWeight, maximumPayload, height, depth, true);
gas1.Load(cargoWeight);
Container gas2 = new GasContainer(tareWeight, maximumPayload, height, depth, false);
gas2.Load(333);
Container refrigerated1 = new RefrigeratedContainer(Product.Chocolate, tareWeight, maximumPayload, height, depth);
refrigerated1.Load(cargoWeight);
Container refrigerated2 = new RefrigeratedContainer(Product.Bananas, tareWeight, maximumPayload, height, depth);
refrigerated2.Load(2045);

Console.WriteLine(refrigerated1);

Ship ship1 = new Ship();
ship1.MaxContainers = 10;
ship1.MaxWeight = 50000;
ship1.MaxSpeed = 300;

ship1.LoadContainer(liquid1);

List<Container> containers = [gas1, gas2, refrigerated1, refrigerated2];

ship1.LoadContainers(containers);
Console.WriteLine(ship1);

ship1.RemoveContainer(gas2);
gas2.Unload();

ship1.ReplaceContainer(liquid1.SerialNumber, liquid2);

Ship ship2 = new Ship();
ship2.MaxContainers = 1;
ship2.MaxWeight = 50000;
ship1.TransferContainer(refrigerated1, ship2);

Console.WriteLine(ship1);
Console.WriteLine(ship2);



TryCatch(() =>
{
    gas2.Load(5000);
});

TryCatch(() =>
{
    ship1.TransferContainer(refrigerated2, ship2);
});
