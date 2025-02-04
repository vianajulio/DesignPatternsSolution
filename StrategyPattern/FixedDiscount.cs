namespace StrategyPattern;
public class FixedDiscount : IDiscountStrategy
{
    private readonly decimal _discountAmount;

    public FixedDiscount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
    }

    public decimal ApplyDiscount(decimal amount)
    {
        return amount - _discountAmount;
    }
}
