namespace CodeSmellsCodeExercise
{
    internal class Fixed_Program
    {
        static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor(new ProductDatabase());

            Customer customer1 = new Customer("Jane Doe", "California");
            Customer customer2 = new Customer("John Doe", "New York");

            Order order1 = new Order(customer1, new List<string> { "Laptop", "Phone" }, new List<double> { 1200, 800 }, new List<int> { 1, 2 });
            Order order2 = new Order(customer2, new List<string> { "Tablet", "Monitor", "Keyboard" }, new List<double> { 300, 200, 50 }, new List<int> { 1, 1, 1 });

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

                try
                {
                    _db.SaveOrder(order);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving order: " + ex.Message);
                }
            }
        }
    }
}
