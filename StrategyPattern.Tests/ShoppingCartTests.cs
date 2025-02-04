namespace StrategyPattern.Tests;

public class ShoppingCartTests
{
    [Fact]
    public void CalculateTotal_WithPercentageDiscount_ReturnsCorrectValue()
    {
        var strategy = new PercentageDiscount(0.1m);
        var cart = new ShoppingCart(strategy);
        Assert.Equal(90m, cart.CalculateTotal(100m));
    }

    [Fact]
    public void CalculateTotal_WithFixedDiscount_ReturnsCorrectValue()
    {
        var strategy = new FixedDiscount(10m);
        var cart = new ShoppingCart(strategy);
        Assert.Equal(90m, cart.CalculateTotal(100));
    }

    [Fact]
    public void ReturnTotal_WithNoDiscount_ReturnCorrectValue()
    {
        var strategy = new NoDiscount();
        var cart = new ShoppingCart(strategy);
        Assert.Equal(90m, cart.CalculateTotal(90m));
    }
}
