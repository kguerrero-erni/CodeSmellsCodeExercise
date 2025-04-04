using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
    class TenPercentDiscount : IDiscount
    {
        public double GetDiscountedPrice(double totalCost)
        {
            return totalCost * 0.90;
        }
    }

    class FifteenPercentDiscount : IDiscount
    {
        public double GetDiscountedPrice(double totalCost)
        {
            return totalCost * 0.85;
        }
    }

    class ZeroPercentDiscount : IDiscount
    {
        public double GetDiscountedPrice(double totalCost)
        {
            return totalCost;
        }
    }
}
