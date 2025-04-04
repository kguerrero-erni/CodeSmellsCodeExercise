namespace CodeSmellsCodeExercise;

class DiscountRule : IDiscount
{
        private readonly List<IDiscountRule> _discountRules;

        public DiscountRule(){
            _discountRules = [
                new FifteenPercentDiscount(),
                new TenPercentDiscount(),
                new NoDiscount()
            ];
        }

        public double ApplyDiscount(double totalPrice)
        {
            return _discountRules.First(r => r.isMatch(totalPrice)).apply(totalPrice);
        }
}