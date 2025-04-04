using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.RefactoredVersion.Data;
using CodeSmellsCodeExercise.RefactoredVersion.Services.Interfaces;

namespace CodeSmellsCodeExercise.RefactoredVersion.Services
{
    public class TotalCostCalculator: ITotalCostCalculator
    {
        private Dictionary<string, double> prices = [];
        public TotalCostCalculator()
        {
            prices["Laptop"] = 1200;
            prices["Phone"] = 800;
            prices["Tablet"] = 300;
            prices["Monitor"] = 200;
            prices["Keyboard"] = 50;
        }

        public double CalculateTotalPrice(List<OrderItem> orderItems)
        {
            double totalPrice = 0;

            foreach (var item in orderItems)
            {
                if (item.Quantity <= 0)
                {
                    throw new Exception($"Invalid quantity for product: {item.ProductName}");
                }

                if (!prices.TryGetValue(item.ProductName, out double value))
                {
                    throw new Exception($"Unknown product: {item.ProductName}");
                }

                double itemPrice = value * item.Quantity;
                totalPrice += itemPrice;
            }

            return totalPrice;
        }

    }
}
