using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
    class ProductDatabase : IDatabase
    {
        public void SaveOrder(Order order)
        {
            // Conditional Complexity
            if (!order.IsValid())
                throw new ArgumentException("Invalid order details.");

            try
            {
                Console.WriteLine("Order saved to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving order: " + ex.Message);
            }
        }
    }
}
