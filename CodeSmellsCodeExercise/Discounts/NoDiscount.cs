namespace CodeSmellsCodeExercise;

    public class NoDiscount : IDiscountRule
    {
        public bool isMatch(double totalPrice)
        {
            return true;
        }

        public double apply(double totalPrice)
        {
            return totalPrice;
        }
    }
