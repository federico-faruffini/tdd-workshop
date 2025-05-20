using PromoCalculator.DiscountRules;

namespace PromoCalculator.Tests;

public class TwoEuroCouponOnTShirtsTests
{
    [Fact]
    public void GivenCart_WhenCalculateDiscount_ThenReturnsTwo()
    {
        // Arrange 
        var cart = new Cart();
        var coupon = new TwoEuroCouponOnTShirts();

        // Act
        var result = coupon.CalculateDiscount(cart);

        // Assert
        Assert.Equal(2m, result);
    }

    [Fact]
    public void GivenCartHasTotalBiggerThanTwoEuroAndNoTShirt_WhenIsApplicable_ThenReturnsFalse()
    {
        // Arrange 
        var cart = new Cart();
        cart.Add(new Product("red bottle", 3m, ProductType.General), 1);

        var coupon = new TwoEuroCouponOnTShirts();

        // Act
        var result = coupon.IsApplicable(cart);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GivenCartHasTotalLesserThanTwoEuroAndNoTShirt_WhenIsApplicable_ThenReturnsFalse()
    {
        // Arrange 
        var cart = new Cart();
        cart.Add(new Product("blue socks", 1.5m, ProductType.General), 1);

        var coupon = new TwoEuroCouponOnTShirts();

        // Act
        var result = coupon.IsApplicable(cart);

        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void GivenCartHasTotalBiggerThanTwoEuroAndTShirt_WhenIsApplicable_ThenReturnsFalse()
    {
        // Arrange 
        var cart = new Cart();
        cart.Add(new Product("blue socks", 1.5m, ProductType.General), 2);
        cart.Add(new Product("blue tshirt", 4m, ProductType.TShirt), 1);

        var coupon = new TwoEuroCouponOnTShirts();

        // Act
        var result = coupon.IsApplicable(cart);

        // Assert
        Assert.True(result);
    }
}