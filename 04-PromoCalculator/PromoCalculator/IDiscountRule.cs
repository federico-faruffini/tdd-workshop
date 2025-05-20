namespace PromoCalculator;

public interface IDiscountRule
{
    bool IsApplicable(Cart cart);
    decimal CalculateDiscount(Cart cart);
}
