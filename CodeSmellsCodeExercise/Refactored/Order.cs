using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Refactored
{
    public class Order(Customer customer)
    {
        public Customer customer = customer;
        public List<OrderItem> items = new List<OrderItem>();

        public void AddItem(string productName, int quantity)
        {
            ProductCatalog catalog = new ProductCatalog();

            if (!catalog.Exists(productName))
            {
                Console.WriteLine($"Cannot add unknown product: {productName}");
                return;
            }

            items.Add(new OrderItem(productName, quantity));
        }
    }
}
