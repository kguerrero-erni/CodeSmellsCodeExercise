using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.RefactoredVersion.Services;
using CodeSmellsCodeExercise.RefactoredVersion.Services.Interfaces;

namespace CodeSmellsCodeExercise.RefactoredVersion.Data
{
    public class Database(IOrderValidator orderValidator): IDatabase
    {
        private List<Order> orders = [];
        private readonly IOrderValidator orderValidator = orderValidator;

        public void SaveOrder(Order order)
        {
            if (!orderValidator.IsValid(order.Customer))
            {
                throw new Exception("Invalid customer details.");
            }

            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                throw new Exception("Order must have at least one item.");
            }

            orders.Add(order);
            Console.WriteLine($"Order for {order.Customer.Name} at {order.Customer.Address} saved.");
            Console.WriteLine();
        }

        public void DisplayOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine($"Customer: {order.Customer.Name}");
                Console.WriteLine($"Address: {order.Customer.Address}");
                Console.WriteLine("Orders:");

                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine($"* {item.ProductName} x{item.Quantity}");
                }

                Console.WriteLine(); 
            }
        }

    }
}
