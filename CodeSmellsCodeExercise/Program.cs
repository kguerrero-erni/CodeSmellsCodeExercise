using CodeSmellsCodeExercise.RefactoredVersion;
using CodeSmellsCodeExercise.RefactoredVersion.Data;
using CodeSmellsCodeExercise.RefactoredVersion.Services;

namespace CodeSmellsCodeExercise
{	
	//LARGE CLASS
    internal class Program
    {
        static void Main(string[] args)
        {
			OrderProcessor orderProcessorA = new OrderProcessor();

            //LONG PARAMETER LIST
            //DEAD CODE -- new List<double> { 300, 200, 50 }
            //OLD code using old classes and methods
            orderProcessorA.ProcessOrder("Jane Doe", "California", new List<string> { "Laptop", "Phone" }, new List<double> { 1200, 800 }, new List<int> { 1, 2 });
            orderProcessorA.ProcessOrder("John Doe", "New York", new List<string> { "Tablet", "Monitor", "Keyboard" }, new List<double> { 300, 200, 50 }, new List<int> { 1, 1, 1 });

			//Console.ReadLine();

			Console.WriteLine("*************************************\n");

            //NEW Code using refactored classes and methods
            var OrderValidator = new OrderValidator();
			var TotalCostCalculator = new TotalCostCalculator();
			var Database = new Database(OrderValidator);

            RefactoredOrderProcessor orderProcessorB = new RefactoredOrderProcessor(OrderValidator, TotalCostCalculator, Database);
			orderProcessorB.ProcessOrder(new Order(new Customer("Henry", "Manila"), [new OrderItem("Laptop", 1), new OrderItem("Phone", 2)]));

			Database.DisplayOrders();
		}

		class OrderProcessor
		{
			private Dictionary<string, double> prices = new Dictionary<string, double>();

			public OrderProcessor()
			{
				prices["Laptop"] = 1200;
				prices["Phone"] = 800;
				prices["Tablet"] = 300;
				prices["Monitor"] = 200;
				prices["Keyboard"] = 50;
			}

            //LONG PARAMETER LIST
            //PRIMITIVE OBSESSION
            //DEAD CODE  -- List<double> productPrices
            public void ProcessOrder(string customerName, string customerAddress, List<string> productNames, List<double> productPrices, List<int> quantities)
			{
				//DUPLICATED
				if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerAddress))
				{
					Console.WriteLine("Invalid customer details.");
					return;
				}	

				double totalPrice = 0;

				for (int i = 0; i < productNames.Count; i++)
				{
					if (!prices.ContainsKey(productNames[i]))
					{
						Console.WriteLine($"Unknown product: {productNames[i]}");
						continue;
					}
					double itemPrice = prices[productNames[i]] * quantities[i];
					totalPrice += itemPrice;
				}

                if (totalPrice > 2000)
				{
					totalPrice *= 0.85; // Apply 15% discount
				}
				else if (totalPrice > 1000)
				{
					totalPrice *= 0.90; // Apply 10% discount
				}

				Console.WriteLine($"Order for {customerName} at {customerAddress} processed. Total: {totalPrice}");

				try
				{
                    //FEATURE ENVY
                    Database.SaveOrder(customerName, customerAddress, productNames, quantities, totalPrice);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error saving order: " + ex.Message);
				}
			}

			
			class Database
			{
                //LONG PARAMETER LIST
                public static void SaveOrder(string customerName, string customerAddress, List<string> products, List<int> quantities, double total)
				{
					//DUPLICATED
					if (string.IsNullOrEmpty(customerName) || total <= 0)
					{
						throw new ArgumentException("Invalid order details.");
					}
					Console.WriteLine("Order saved to database.");
				}
			}
		}
    }
}
