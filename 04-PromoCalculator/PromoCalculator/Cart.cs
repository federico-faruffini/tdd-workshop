namespace PromoCalculator;

public class Cart
{
    private readonly List<CartItem> _items = new();

    public void Add(Product product, int quantity)
    {
        _items.Add(new CartItem(product, quantity));
    }

    public IReadOnlyList<CartItem> Items => _items;

    public decimal Total => _items.Sum(item => item.Total);
}
