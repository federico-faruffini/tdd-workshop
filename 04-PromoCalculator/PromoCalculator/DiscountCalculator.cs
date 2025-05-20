namespace PromoCalculator;

public class DiscountCalculator
{
    private readonly List<IDiscountRule> _rules;
    private const decimal MaxDiscount = 20;

    public DiscountCalculator(IEnumerable<IDiscountRule> rules)
    {
        _rules = rules.ToList();
    }

    public decimal CalculateTotal(Cart cart)
    {
        throw new NotImplementedException();
    }
}
