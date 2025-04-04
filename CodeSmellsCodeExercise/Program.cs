namespace CodeSmellsCodeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
			OrderProcessor orderProcessor = new OrderProcessor();
			orderProcessor.ProcessOrder("Jane Doe", "California", new List<string> { "Laptop", "Phone" }, new List<double> { 1200, 800 }, new List<int> { 1, 2 });
			orderProcessor.ProcessOrder("John Doe", "New York", new List<string> { "Tablet", "Monitor", "Keyboard" }, new List<double> { 300, 200, 50 }, new List<int> { 1, 1, 1 });

			Console.ReadLine();
		}


		class OrderProcessor
		{
			private Dictionary<string, double> prices = new Dictionary<string, double>();

			public OrderProcessor()
			{
				// Duplicate Code
				prices["Laptop"] = 1200;
				prices["Phone"] = 800;
				prices["Tablet"] = 300;
				prices["Monitor"] = 200;
				prices["Keyboard"] = 50;
			}

			// Data Clumps - ProcessOrder Method has a long parameter - Create an Order Class
			// Long Methods - ProcessOrder has a lot of code - Extract lines of code such as for loop and if statements
			// Dead Code - productPrices parameter is not used - Remove parameter or Use as the price basis 
			public void ProcessOrder(string customerName, string customerAddress, List<string> productNames, List<double> productPrices, List<int> quantities)
			{
				// Conditional Complexity and Duplicated Code - Long Condition and duplicated on Database - Create Separate Method to Validate Order
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
					// Tight coupling
					Database.SaveOrder(customerName, customerAddress, productNames, quantities, totalPrice);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error saving order: " + ex.Message);
				}
			}

			class Database
			{
                // Data Clumps - SaveOrder Method has a long parameter - Create an Order Class
                public static void SaveOrder(string customerName, string customerAddress, List<string> products, List<int> quantities, double total)
				{
					// Conditional Complexity
					if (string.IsNullOrEmpty(customerName) || total <= 0)
					{
						throw new ArgumentException("Invalid order details.");
					}
					// Lack of Error handling - Saving to database does not have a try-catch statement - Create Try-Catch Statement
					Console.WriteLine("Order saved to database.");
				}
			}
		}
    }
}
