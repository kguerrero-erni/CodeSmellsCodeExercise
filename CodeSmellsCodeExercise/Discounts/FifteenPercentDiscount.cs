namespace CodeSmellsCodeExercise;

class FifteenPercentDiscount : IDiscountRule
{
    public bool isMatch(double totalPrice)
    {
        return totalPrice > 2000;
    }
    public double apply(double totalPrice)
    {
        return totalPrice * 0.85;
    }
}