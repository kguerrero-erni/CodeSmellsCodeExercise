using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
    public interface IDiscount
    {
        double GetDiscountedPrice(double totalCost);
    }
}
