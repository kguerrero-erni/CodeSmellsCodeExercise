using CodeSmellsCodeExercise.Interface;
using CodeSmellsCodeExercise.Entities;


namespace CodeSmellsCodeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
			IDiscount discount = new Discount();
			ICalculateOrder calculateOrder = new OrderProcessor();
			IDatabase database = new Database();


			ProcessingOrder orderProcessor = new ProcessingOrder(discount, calculateOrder,database);

			CustomerDetails customer1 = new CustomerDetails("Jane Doe", "California");
			Product product1 = new Product(new List<string> { "Laptop", "Phone" },  new List<int> { 1, 2 });

			CustomerDetails customer3 = new CustomerDetails("John Doe", "New York");
			Product product3 = new Product(new List<string> { "Tablet" }, new List<int> { 4 });
			
			
			orderProcessor.ProcessOrder(customer1,product1);
			orderProcessor.ProcessOrder(customer3,product3);

			Console.ReadLine();
		}

		
    }
}
