namespace APBD3;

public enum Product
{
    Bananas, 
    Chocolate,
    Fish, 
    Meat,
    IceCream,
    FrozenPizza,
    Cheese,
    Sausages, 
    Butter,
    Eggs
}

public static class ProductExtensions
{
    public static float Temperature(this Product product)
    {
        return product switch
        {
            Product.Bananas => 13.3f,
            Product.Chocolate => 18f,
            Product.Fish => 2f,
            Product.Meat => -15,
            Product.IceCream => -18,
            Product.FrozenPizza => -30,
            Product.Cheese => 7.2f,
            Product.Sausages => 5,
            Product.Butter => 20.5f,
            Product.Eggs => 19
        };
    }
}