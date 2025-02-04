namespace StrategyPattern;

public class ShoppingCart
{
    private IDiscountStrategy _discountStrategy;

    public ShoppingCart(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal CalculateTotal(decimal amount)
    {
        return _discountStrategy.ApplyDiscount(amount);
    }
}
