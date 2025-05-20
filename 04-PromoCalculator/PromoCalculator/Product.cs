namespace PromoCalculator;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public ProductType ProductType { get; }

    public Product(string name, decimal price, ProductType productType = ProductType.General)
    {
        Name = name;
        Price = price;
        ProductType = productType;
    }
}
