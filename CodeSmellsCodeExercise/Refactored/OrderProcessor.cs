using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Refactored
{
    public class OrderProcessor
    {
        public double CalculateDiscount(double totalPrice)
        {
            double discount = 1;

            if (totalPrice > 2000)
            {
                discount = 0.85; // Apply 15% discount
            }
            else if (totalPrice > 1000)
            {
                discount = 0.90; // Apply 10% discount
            }
            return discount;
        }

        public double CalculateTotalPrice(Order order, double discount)
        {
            ProductCatalog catalog = new ProductCatalog();
            double total = 0;

            foreach (OrderItem item in order.items)
            {
                double? price = catalog.GetPrice(item.name);
                total += price.Value * item.quantity;
            }

            return total * discount;

        }
        public void SaveOrder(Order order)
        {
            Console.WriteLine("Order saved to database.");
        }
    }
}
