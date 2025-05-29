namespace PromoCalculator;

public class DiscountCalculator
{
    private readonly List<IDiscountRule> _rules;

    public DiscountCalculator(IEnumerable<IDiscountRule> rules)
    {
        _rules = rules.ToList();
    }

    public DiscountCalculator() : this(Enumerable.Empty<IDiscountRule>())
    {
    }

    public decimal CalculateTotalWithDiscounts(Cart cart)
    {
        throw new NotImplementedException();
    }
}
