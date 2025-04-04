using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.RefactoredVersion.Domain.DiscountStrategy
{
    public class FifteenPercentDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double totalPrice)
        {
            return totalPrice * 0.85;
        }
    }
}
