namespace CodeSmellsCodeExercise
{
    internal class Fixed_Program
    {
        static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor(new ProductDatabase());

            Customer customer1 = new Customer("Jane Doe", "California");
            Customer customer2 = new Customer("John Doe", "New York");

            var order1Products = new List<Product>
            {
                new Product("Laptop", 1200, 1),
                new Product("Phone", 800, 2)
            };

            var order2Products = new List<Product>
            {
                new Product("Tablet", 300, 1),
                new Product("Monitor", 200, 1),
                new Product("Keyboard", 50, 1)
            };

            Order order1 = new Order(customer1, order1Products);
            Order order2 = new Order(customer2, order2Products);

            orderProcessor.ProcessOrder(order1);
            orderProcessor.ProcessOrder(order2);

            Console.ReadLine();
        }

        class OrderProcessor
        {
            private IDatabase _db;

            public OrderProcessor(IDatabase db)
            {
                _db = db;
            }

            public void ProcessOrder(Order order)
            {
                var customer = order.customer;

                if (customer.IsEmpty())
                {
                    Console.WriteLine("Invalid customer details.");
                    return;
                }

                order.ComputeTotalCost();

                DiscountProvider.ApplyDiscount(order);

                order.DisplayDetails();

                _db.SaveOrder(order);
            }
        }
    }
}
