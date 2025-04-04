using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
    public class DiscountProvider
    {
        public static void ApplyDiscount(Order order)
        {
            var totalPrice = order.totalPrice;

            var discount = FetchDiscount(totalPrice);

            order.totalPrice = discount.GetDiscountedPrice(totalPrice);
        }

        public static IDiscount FetchDiscount(double totalPrice)
        {
            if (totalPrice > 2000)
                return new FifteenPercentDiscount();
            else if (totalPrice > 1000)
                return new TenPercentDiscount();
            else
                return new ZeroPercentDiscount();
        }
    }
}
