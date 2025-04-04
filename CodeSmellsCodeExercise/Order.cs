using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
    public class Order
    {
        public Customer customer { get; }

        private List<Product> products = new List<Product>();
        public double totalPrice { get; set; }

        public Order(Customer customer, List<string> productNames, List<double> productPrices, List<int> productQuantity)
        {
            this.customer = customer;

            for (int i = 0; i < productNames.Count; i++)
                products.Add(new Product(productNames[i], productPrices[i], productQuantity[i]));
        }

        public bool IsValid()
        {
            return customer.IsEmpty() || totalPrice > 0;
        }

        public void ComputeTotalCost()
        {
            totalPrice = products.Select(p => p.Price * p.Quantity).Sum();
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Order for {customer.Name} at {customer.Address} processed. Total: {totalPrice}");
        }
    }
}
