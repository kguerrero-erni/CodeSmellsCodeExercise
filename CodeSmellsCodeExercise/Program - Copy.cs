using System.Diagnostics;
using System.Xml.Linq;

namespace CodeSmellsCodeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Validation validate = new Validation();
            OrderInventory inventory = new OrderInventory();
            OrderProcessor orderProcessor = new OrderProcessor();
            DiscountPrice discountPrice = new DiscountPrice();
            try
            {
                customer.GetCustomerDetails("John Doe", "California");
                validate.ValidateCustomerDetails(customer.customerName,customer.customerAddress);
                orderProcessor.AddOrder("Laptop", 1);
                orderProcessor.AddOrder("Towel", 2);
                double price = orderProcessor.ProcessOrder();
                validate.ValidateOrder(price);
                price = discountPrice.GetDiscount(price);

                Console.WriteLine($"Order for {customer.customerName} at {customer.customerAddress} processed. Total: {price}");

                inventory.SaveOrder(customer, orderProcessor);
                orderProcessor.ClearOders();

                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        class Customer
        {
            public string customerName;
            public string customerAddress;

            public void GetCustomerDetails(string name, string address)
            {
                customerName = name;
                customerAddress = address;
            }
        }
        class OrderProcessor
        {
            private Dictionary<string, double> productPrices = new Dictionary<string, double>();
            public OrderProcessor()
            {

                productPrices["Laptop"] = 1200;
                productPrices["Phone"] = 800;
                productPrices["Tablet"] = 300;
                productPrices["Monitor"] = 200;
                productPrices["Keyboard"] = 50;
            }
            public List<string> productNames = new List<string>();
            public List<int> quantities = new List<int>();

            public void AddOrder(string productName, int quantity)
            {
                productNames.Add(productName);
                quantities.Add(quantity);
            }
            public double ProcessOrder()
            {
                double totalPrice = 0;

                for (int i = 0; i < productNames.Count; i++)
                {
                    if (!productPrices.ContainsKey(productNames[i]))
                    {
                        Console.WriteLine($"Unknown product: {productNames[i]}");
                        continue;
                    }

                    double itemPrice = productPrices[productNames[i]] * quantities[i];
                    totalPrice += itemPrice;
                }
                return totalPrice;
            }

            public void ClearOders()
            {
                productNames.Clear();
                quantities.Clear();
            }
        }
        class DiscountPrice
        {
            public double discountedPrice;
            public double GetDiscount(double price)
            {
                discountedPrice = price;
                if ( discountedPrice > 1000)
                {
                    return discountedPrice *= 0.85;
                }
                else if ( discountedPrice > 2000)
                {
                    return discountedPrice *= 0.90;
                }
                return price;
            }
        }
        class Validation
        {
            public void ValidateOrder(double total)
            {
                if (total <= 0)
                {
                    throw new ArgumentException("Invalid order details.");
                }
            }

            public void ValidateCustomerDetails(string name, string address)
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address))
                {
                    throw new ArgumentException("Invalid customer details.");
                }
            }
        }
        class OrderInventory
        { 
            public void SaveOrder(Customer customer, OrderProcessor orders)
            {

                Console.WriteLine("Order saved to database.\n");
                Console.WriteLine($"Order saved to database for customer: {customer.customerName}, {customer.customerAddress}");
                Console.WriteLine("Order details:");
                for (int i = 0; i < orders.productNames.Count; i++)
                {
                    Console.WriteLine($"Product: {orders.productNames[i]}, Quantity: {orders.quantities[i]}");
                }
                Console.WriteLine();
            }
        }

    }
}
