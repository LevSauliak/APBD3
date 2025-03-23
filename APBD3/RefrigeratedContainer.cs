namespace APBD3;

public class RefrigeratedContainer: Container
{
    public override string Type => "C";
    public Product Product { get; set; }

    public float temperature
    {
        get
        {
            return temperature;
        }
        set
        {
            if (value <= Product.Temperature())
            {
               temperature = value; 
            }
        }
    }

    public RefrigeratedContainer(Product product, uint tareWeight, uint maximumPayload, uint height, uint depth) 
        : base (tareWeight, maximumPayload, height, depth)
    {
        this.Product = product;
    }

    public override string ToString()
    {
        return base.ToString()+$"\n{Product}";
    }
}