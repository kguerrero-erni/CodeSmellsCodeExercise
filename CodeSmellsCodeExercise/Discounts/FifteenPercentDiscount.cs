namespace CodeSmells;

class FifteenPercentDiscount : IDiscountRule
{
    public bool isMatch(double totalPrice)
    {
        return totalPrice > 1000;
    }
    public double apply(double totalPrice)
    {
        return totalPrice * 0.85;
    }
}