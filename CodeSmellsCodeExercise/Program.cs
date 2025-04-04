namespace CodeSmells;

    internal class Program
    {
        static void Main(string[] args)
        {
            IDiscount discount = new DiscountRule();
            IOrderRepository orderRepository = new OrderRepository();

			OrderProcessor orderProcessor = new OrderProcessor(discount, orderRepository);

			var order1 = new Order(new Customer("John Doe", "California"), 
            new List<Product> {
                new Product("Laptop", 1),
                new Product("Phone", 2)
            });

            orderProcessor.ProcessOrder(order1);
			Console.ReadLine();
        }
    
}
