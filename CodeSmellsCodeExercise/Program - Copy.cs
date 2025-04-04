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
            Validation validate = new Validation();
            Database database = new Database();
            OrderProcessor orderProcessor = new OrderProcessor();
            DiscountPrice discountPrice = new DiscountPrice();
            DisplayInfo displayInfo = new DisplayInfo();

            try
            {
                customer.GetCustomerDetails("John Doe", "California");
                validate.ValidateCustomerDetails(customer.customerName, customer.customerAddress);
                
                orderProcessor.AddOrder("Laptop", 1);
                orderProcessor.AddOrder("Towel", 1);
                
                double price = orderProcessor.ProcessOrder();
                
                validate.ValidateOrder(price);
                
                discountPrice.GetDiscount(price);
                
                displayInfo.display(customer, price);
                
                database.SaveOrder(customer, orderProcessor);
                
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving order: "+ ex.Message);
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
                        //throw new ArgumentException($"Unknow product {productNames[i]}");

                        continue;
                    }

                    double itemPrice = productPrices[productNames[i]] * quantities[i];
                    totalPrice += itemPrice;
                }
                return totalPrice;
            }

            public void ClearOrders()
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
                if (discountedPrice > 1000)
                {
                    return discountedPrice *= 0.85;
                }
                else if (discountedPrice > 2000)
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
        class Database
        {
            public void SaveOrder(Customer customer, OrderProcessor orders)
            {

                Console.WriteLine("Order saved to database.\n");
                orders.ClearOrders();
            }
        }
        class DisplayInfo
        {
            public void display(Customer customer, double price)
            {
                Console.WriteLine($"Order for {customer.customerName} at {customer.customerAddress} processed. Total: {price}");
            }

        }
    }
}


