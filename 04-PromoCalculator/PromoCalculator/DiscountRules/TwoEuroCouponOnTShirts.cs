namespace PromoCalculator.DiscountRules
{
    public class TwoEuroCouponOnTShirts : IDiscountRule
    {
        private const decimal discountValue = 2m;

        public decimal CalculateDiscount(Cart cart)
        {
            return discountValue;
        }

        public bool IsApplicable(Cart cart)
        {
            if (cart.Total < discountValue)
            {
                return false;
            }

            return cart.Items.Any(x => x.Product.ProductType == ProductType.TShirt);
        }
    }
}