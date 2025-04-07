using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeSmellsCodeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            OrderProcessor orderProcessor = new OrderProcessor();
            Database database = new Database();

            try
            {
                customer.CustomerDetails("Jane Doe", "California");
                orderProcessor.AddOrder("Laptop", 1);
                orderProcessor.AddOrder("Phone", 2);
                orderProcessor.ProcessOrder();
                database.SaveOrder(customer, orderProcessor);



                customer.CustomerDetails("John Doe", "New York");
                orderProcessor.AddOrder("Tablet", 1);
                orderProcessor.AddOrder("Monitor", 1);
                orderProcessor.AddOrder("Keyboard", 1);
                orderProcessor.ProcessOrder();
                database.SaveOrder(customer, orderProcessor);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        class Customer
        {
            public string customerName { get; set; }
            public string customerAddress { get; set; }

            public void CustomerDetails(string name, string address)
            {
                customerName = name;
                customerAddress = address;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address))
                {
                    throw new ArgumentException("Invalid customer details.");
                }

                Console.WriteLine($"Order for : {customerName} at {customerAddress}.");
            }
        }
        class OrderProcessor
        {
            private Dictionary<string, double> productPrices = new Dictionary<string, double>();
            public Dictionary<string, int> savedOrders = new Dictionary<string, int>();

            public List<int> quantities = new List<int>();
            public List<string> productNames = new List<string>();

            public OrderProcessor()
            {

                productPrices["Laptop"] = 1200;
                productPrices["Phone"] = 800;
                productPrices["Tablet"] = 300;
                productPrices["Monitor"] = 200;
                productPrices["Keyboard"] = 50;
            }
            public void AddOrder(string productName, int quantity)
            {
                productNames.Add(productName);
                quantities.Add(quantity);
            }

            public void ProcessOrder()
            {

                double totalPrice = 0;

                for (int i = 0; i < productNames.Count; i++)
                {
                    if (!productPrices.ContainsKey(productNames[i]))
                    {
                        Console.WriteLine($"Unknown product: {productNames[i]}");
                        continue;
                    }

                    savedOrders.Add(productNames[i], quantities[i]);

                    double itemPrice = productPrices[productNames[i]] * quantities[i];
                    totalPrice += itemPrice;
                }

                if (totalPrice <= 0)
                {
                    throw new ArgumentException("Invalid order details.");
                }
                
                totalPrice = Discount(totalPrice);

                Console.WriteLine($"Total price: {totalPrice}");

            }

            public double Discount(double totalPrice)
            {
                if (totalPrice > 1000 && totalPrice < 2000)
                {
                    return totalPrice * 0.90;
                }
                else if (totalPrice > 2000)
                {
                    return totalPrice * 0.85;
                }
                return totalPrice;
            }

            public void ClearOrders()
            {
                productNames.Clear();
                quantities.Clear();
            }

           
        }

        class Database
        {
            public void SaveOrder(Customer customer, OrderProcessor orders)
            {
                
                Console.WriteLine($"Customer details: {customer.customerName} {customer.customerAddress}\n");
                foreach (var order in orders.savedOrders)
                {
                    Console.WriteLine($"Product: {order.Key}, Quantity: {order.Value}");
                }

                Console.WriteLine("Order saved to database.\n");
                
                orders.productNames.Clear();
                orders.quantities.Clear();
                
            }
        }

    }
}

