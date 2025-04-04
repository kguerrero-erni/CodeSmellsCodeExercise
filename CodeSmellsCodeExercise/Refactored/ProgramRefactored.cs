namespace CodeSmellsCodeExercise.Refactored
{
    internal class ProgramRefactored
    {
        static void Main(string[] args)
        {
            var customer = new Customer("John Doe", "New York"); 
            var order = new Order(customer);
            order.AddItem("Tablet", 1);
            order.AddItem("Monitor",1);
            order.AddItem("Keyboard", 1);
          
            ProcessOrder(customer, order);

            var customer2 = new Customer("Jane Doe", "California");
            var order2 = new Order(customer2);
            order2.AddItem("Laptoping", 1);
            order2.AddItem("Phone", 2);

            ProcessOrder(customer2, order2);
        }
        static void ProcessOrder(Customer customer, Order order)
        {
            ValidateCustomer(customer);

            var processor = new OrderProcessor();
            
            double rawTotal = processor.CalculateTotalPrice(order, 1.0);
            double discount = processor.CalculateDiscount(rawTotal);
            double finalTotal = processor.CalculateTotalPrice(order, discount);
            
            Console.WriteLine($"Order for {customer.name} at {customer.address} processed. Total: {finalTotal}");
            
          
            processor.SaveOrder(order);
        }
        static void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.name) || string.IsNullOrEmpty(customer.address))
            {
                Console.WriteLine("Invalid customer details.");
                return;
            }
        }
    }
}
