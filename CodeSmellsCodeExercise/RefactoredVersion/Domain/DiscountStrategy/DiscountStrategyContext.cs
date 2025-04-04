using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.RefactoredVersion.Domain.DiscountStrategy
{
    public class DiscountStrategyContext
    {
        public static IDiscountStrategy GetDiscountStrategy(double totalPrice)
        {
            if (totalPrice > 2000)
            {
                return new FifteenPercentDiscount();
            }
            else if (totalPrice > 1000)
            {
                return new TenPercentDiscount();
            }
            return new NoDiscount();
        }
    }
}
