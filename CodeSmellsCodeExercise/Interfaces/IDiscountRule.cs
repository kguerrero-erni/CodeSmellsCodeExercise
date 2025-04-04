namespace CodeSmellsCodeExercise;

interface IDiscountRule
{
    public bool isMatch(double totalPrice);
    public double apply(double totalPrice);
}