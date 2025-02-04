namespace StrategyPattern;

public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal amount);
}
