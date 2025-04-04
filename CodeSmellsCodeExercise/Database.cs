using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Interface;
using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise
{
    public class Database : IDatabaseRepository
    {
        public void SaveOrder(OrderDetails orderDetails)
        {
            if (IsOrderValid(orderDetails))
            {
                throw new ArgumentException("Invalid order details.");
            }
            Console.WriteLine("Order saved to database.");
        }

        private Boolean IsOrderValid(OrderDetails orderDetails)
        {
            if(string.IsNullOrEmpty(orderDetails.Customer.Name) || orderDetails.DiscountedPrice <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
