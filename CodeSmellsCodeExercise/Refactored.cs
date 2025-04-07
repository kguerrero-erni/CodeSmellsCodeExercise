namespace CodeSmellsCodeExercise
{
    internal class Refactored
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer = new Customer("John Doe", "New York");
                ItemList itemList = new ItemList();
                Cart products = new Cart(itemList);

                products.AddToCart("Laptop", 1);
                products.AddToCart("Monitor", 2);
                products.AddToCart("Keyboard", 1);
                products.RemoveItemFromCart("Monitor", 1);

                OrderProcessor orderProcessor = new OrderProcessor(customer,products, itemList);
                orderProcessor.ProcessOrder(customer, products);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        class Customer
        {
            public string Name { get; }
            public string Address { get; }
            public Customer(string name, string address)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException(nameof(name), "Customer name cannot be empty.");
                }
                if (string.IsNullOrWhiteSpace(address))
                {
                    throw new ArgumentNullException(nameof(address), "Customer address cannot be empty.");
                }

                Name = name;
                Address = address;
            }
        }
        class Cart
        {
            private Dictionary<string, int> cart = new Dictionary<string, int>();
            private readonly ItemList _itemList;
            public Cart(ItemList itemList)
            {
                _itemList = itemList;
            }

            public Dictionary<string,int> GetCart()
            {
                return cart;
            }

            public int GetQuantity(string name)
            {
                return cart[name];
            }

            public void AddToCart(string name, int quantity)
            {
                if (_itemList.IsInPriceList(name))
                {

                    if (IsInCart(name))
                    {
                        cart.Add(name, cart[name] + quantity);
                    }
                    else
                    {
                        Console.WriteLine($"Added `Product Name: {name} , Quantity: {quantity}` to cart.");
                        cart[name] = quantity;
                    }
                }
                else
                {
                    throw new KeyNotFoundException("Item does not exist in price list.");
                }

            }
            
            public void RemoveItemFromCart(string name, int quantity)
            {
                if (!cart.ContainsKey(name))
                {
                    throw new KeyNotFoundException("Item does not exist in the cart.");
                }

                if (cart[name] <= quantity) 
                {
                    Console.WriteLine($"Removed `Product Name: {name}` from cart.");
                    cart.Remove(name);
                }
                else
                {
                    cart[name] -= quantity;
                    Console.WriteLine($"Removed `Product Name: {name}, Quantity: {quantity}` from cart.");
                }
            }

            public bool IsInCart(string name)
            {
                return cart.ContainsKey(name);
            }

            public void Clear() 
            {
                if (cart.Count > 0) 
                { 
                    cart.Clear();
                }
                else
                {
                    throw new InvalidOperationException("Cart is empty.");
                }
            }
        }
        class ItemList
        {
            private Dictionary<string, double> prices = new Dictionary<string, double>
            {
                { "Laptop", 1200 },
                { "Phone", 800 },
                { "Tablet", 300},
                { "Monitor", 200},
                { "Keyboard", 50 }
            };
            
            public bool IsInPriceList(string name)
            {
                return prices.ContainsKey(name);
            }
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
                    if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException("Product name cannot be empty."); }
                    if (price < 0) { throw new ArgumentException("Price cannot be negative."); }
                    Name = name;
                    Price = price;
                }

            }

        }

        class OrderProcessor
        {
            private readonly Customer _customer;
            private readonly Cart _cart;
            private readonly ItemList _itemList;

            public OrderProcessor(Customer customer, Cart cart, ItemList itemList)
            {
                _customer = customer;
                _cart = cart;
                _itemList = itemList;
            }

            public void ProcessOrder(Customer customer, Cart cart)
            {
                
                double totalPrice = CalculateTotal();
                totalPrice = ApplyDiscount(totalPrice);

                PrintReceipt($"Order for {customer.Name} from {customer.Address} processed. Total: {totalPrice}.");

                PrintReceipt($"Cart:");

                foreach(var item in cart.GetCart().Keys)
                {
                    PrintReceipt("\t" + item + ": " + cart.GetQuantity(item));
                }

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
                    totalPrice += _itemList.GetPrice(product) * cart[product];
                    
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
           public static void SaveOrder(Customer customer, Cart cart, double total)
           {
                Console.WriteLine("Order saved to database.");
           }
        }
    }
}
