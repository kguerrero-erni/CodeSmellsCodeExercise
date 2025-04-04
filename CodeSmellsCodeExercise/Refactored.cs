using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace CodeSmellsCodeExercise
{
    internal class Refactored
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("John Doe", "New York");
            ProductList products = new ProductList();
            ProductManager productManager = new ProductManager();
            products.AddToCart("Laptop", 1);
            products.AddToCart("Monitor", 2);
            products.AddToCart("Keyboard", 1);
            OrderProcessor orderProcessor = new OrderProcessor(customer,products,productManager);
            orderProcessor.ProcessOrder(customer, products);
        }

        class Customer
        {
            public string Name { get; }
            public string Address { get; }
            public Customer(string name, string address)
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
                {
                    throw new ArgumentException("Invalid customer information.");
                }
                Name = name;
                Address = address;
            }
        }
        class ProductList
        {
            private Dictionary<string, int> cart = new Dictionary<string, int>();

            public Dictionary<string,int> GetCart()
            {
                return cart;
            }

            public void AddToCart(string name, int quantity)
            {
                if (CheckIfExist(name))
                {
                    cart.Add(name, cart[name] + quantity);
                }
                else
                {
                    cart[name] = quantity;
                }
            }
            
            public void RemoveItemFromCart(string name, int quantity)
            {
                if (CheckIfExist(name))
                {
                    cart.Remove(name);
                }
                else { throw new ArgumentException("Unable to remove item. Item does not exist."); }
            }

            public bool CheckIfExist(string name)
            {
                if (!cart.ContainsKey(name))
                {
                    return false;
                }
                return true;
            }

            public void Clear() 
            {
                if (cart.Count > 0) 
                { 
                    cart.Clear();
                }
                else
                {
                    throw new ArgumentException("Cart is empty.");
                }
            }
        }
        class ProductManager
        {
            private Dictionary<string, double> prices = new Dictionary<string, double>
            {
                { "Laptop", 1200 },
                { "Phone", 800 },
                { "Tablet", 300},
                { "Monitor", 200},
                { "Keyboard", 50 }
            };
            public double GetPrice(string productName)
            {
                return prices[productName];
            }
            public class Product
            {
                public string Name { get; }
                public double Price { get; }

                public Product(string name, double price)
                {
                    if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentException("Product name cannot be empty."); }
                    if (price < 0) { throw new ArgumentException("Price cannot be negative."); }
                    Name = name;
                    Price = price;
                }

            }

        }

        class OrderProcessor
        {
            private readonly Customer _customer;
            private readonly ProductList _cart;
            private readonly ProductManager _productManager;

            public OrderProcessor(Customer customer, ProductList cart, ProductManager productManager)
            {
                _customer = customer;
                _cart = cart;
                _productManager = productManager;
            }

            public void ProcessOrder(Customer customer, ProductList cart)
            {
                
                double totalPrice = CalculateTotal();
                totalPrice = ApplyDiscount(totalPrice);

                PrintReceipt($"Order for {customer.Name} from {customer.Address} processed. Total: {totalPrice}");
                Database.SaveOrder(customer, cart, totalPrice);
            }
            public void PrintReceipt(string message)
            {
                Console.WriteLine(message);
            }
            public double CalculateTotal()
            {
                var cart = _cart.GetCart();
                double totalPrice = 0;

                foreach (var product in cart.Keys)
                {
                    totalPrice += _productManager.GetPrice(product) * cart[product];
                    
                }
                return totalPrice;

            }
            public double ApplyDiscount(double totalPrice)
            {
                if (totalPrice > 2000)
                {
                    totalPrice *= 0.85;
                }
                else if (totalPrice > 1000)
                {
                    totalPrice *= 0.90;
                }
                return totalPrice;

            }

        }
        class Database
        {
           public static void SaveOrder(Customer customer, ProductList cart, double total)
           {
                Console.WriteLine("Order saved to database.");
           }
        }
    }
}
