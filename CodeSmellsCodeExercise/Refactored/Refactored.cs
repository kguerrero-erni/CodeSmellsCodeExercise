using System;
using System.Collections.Generic;

namespace CodeSmellCleanWithOrderItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor();

            var order1 = new Order("Danilo Pelaso", "California", new List<OrderItem>
            {
                new OrderItem("Laptop", 1),
                new OrderItem("Phone", 2),
                new OrderItem("Lamp", 2)
            });

            var order2 = new Order("John Wick", "New York", new List<OrderItem>
            {
                new OrderItem("Tablet", 1),
                new OrderItem("Monitor", 1),
                new OrderItem("Keyboard", 1),
                new OrderItem("Mouse", 2)
            });

            orderProcessor.Process(order1);
            orderProcessor.Process(order2);

            Console.ReadLine();
        }
    }

    class OrderItem
    {
        public string ProductName { get; }
        public int Quantity { get; }

        public OrderItem(string productName, int quantity)
        {
            ProductName = productName;
            Quantity = quantity;
        }
    }

    class Order
    {
        public string CustomerName { get; }
        public string Address { get; }
        public List<OrderItem> Items { get; }

        public Order(string customerName, string address, List<OrderItem> items)
        {
            CustomerName = customerName;
            Address = address;
            Items = items;
        }

        public bool IsValid() =>
            !string.IsNullOrWhiteSpace(CustomerName) &&
            !string.IsNullOrWhiteSpace(Address) &&
            Items != null && Items.Count > 0;
    }

    class OrderProcessor
    {
        private readonly Dictionary<string, double> prices = new()
        {
            { "Laptop", 1200 },
            { "Phone", 800 },
            { "Tablet", 300 },
            { "Monitor", 200 },
            { "Keyboard", 50 },
            { "Mouse", 1000 },
            { "Lamp", 100 }
        };

        public void Process(Order order)
        {
            if (!order.IsValid())
            {
                Console.WriteLine("Invalid order details.");
                return;
            }

            double total = CalculateTotal(order);

            if (total <= 0)
            {
                Console.WriteLine("No valid products in order.");
                return;
            }

            // Apply discount
            total = (total > 2000) ? total * 0.85 :
                    (total > 1000) ? total * 0.90 : total;

            Console.WriteLine($"Order for {order.CustomerName} at {order.Address} processed. Total: {total}");

            try
            {
                SaveOrder(order, total);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving order: {ex.Message}");
            }
        }

        private double CalculateTotal(Order order)
        {
            double total = 0;

            foreach (var item in order.Items)
            {
                if (prices.TryGetValue(item.ProductName, out double price))
                {
                    total += price * item.Quantity;
                }
                else
                {
                    Console.WriteLine($"Unknown product: {item.ProductName}");
                }
            }

            return total;
        }

        private void SaveOrder(Order order, double total)
        {
            if (!order.IsValid() || total <= 0)
                throw new ArgumentException("Invalid order data");

            Console.WriteLine("Order saved to database.");
        }
    }
}
