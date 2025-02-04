namespace StrategyPattern;

public class NoDiscount : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        return amount;
    }
}
