namespace PromoCalculator;

public class Cart
{
    private readonly List<Product> _items = new();

    public void Add(Product product)
    {
        _items.Add(product);
    }

    public void Add(Product product, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            _items.Add(product);
        }
    }

    public IReadOnlyList<Product> Items => _items;

    public decimal TotalBeforeDiscounts => _items.Sum(item => item.Price);
}
