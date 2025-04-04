namespace CodeSmellsCodeExercise;

    internal class Program
    {
        static void Main(string[] args)
        {
            IDiscount discount = new DiscountRule();
            IOrderRepository orderRepository = new OrderRepository();

			OrderProcessor orderProcessor = new (discount, orderRepository);

			var order1 = new Order(new Customer("John Doe", "California"), 
            [
                new Product("Laptop", 1),
                new Product("Phone", 2)
            ]);

            var order2 = new Order(new Customer("Jane Smith", "New York"),
            [
                new Product("Tablet", 1),
                new Product("Monitor", 1),
                new Product("Keyboard", 1)

            ]);
            orderProcessor.ProcessOrder(order1);
            orderProcessor.ProcessOrder(order2);
			Console.ReadLine();
        }
    
}
