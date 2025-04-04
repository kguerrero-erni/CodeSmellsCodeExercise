namespace CodeSmellsCodeExercise
{
    internal class Program
    {
        static void oldMain()
        {
			OrderProcessor orderProcessor = new OrderProcessor();
			// DATA CLUMPS: long list of parameters
			// DUPLICATE CODE: product name and price has already been defined in OrderProcessor
			orderProcessor.ProcessOrder("Jane Doe", "California", new List<string> { "Laptop", "Phone" }, new List<double> { 1200, 800 }, new List<int> { 1, 2 });
			orderProcessor.ProcessOrder("John Doe", "New York", new List<string> { "Tablet", "Monitor", "Keyboard" }, new List<double> { 300, 200, 50 }, new List<int> { 1, 1, 1 });

			Console.ReadLine();
		}
		// LONG CLASS
		// FEATURE ENVY(?) : handles multiple responsibilities like applying discounts and handling orders
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

			//DATA CLUMP: long list of parameters
			public void ProcessOrder(string customerName, string customerAddress, List<string> productNames, List<double> productPrices, List<int> quantities)
			{
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

				// CONDITIONAL COMPLEXITY(?)
				if (totalPrice > 2000)
				{
					totalPrice *= 0.85; // Apply 15% discount
				}
				else if (totalPrice > 1000)
				{
					totalPrice *= 0.90; // Apply 10% discount
				}

				Console.WriteLine($"Order for {customerName} at {customerAddress} processed. Total: {totalPrice}");

				// LACK OF ERROR HANDLING(?): can be improved, more specific exceptions.
				try
				{
					Database.SaveOrder(customerName, customerAddress, productNames, quantities, totalPrice);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error saving order: " + ex.Message);
				}
			}

			class Database
			{
				public static void SaveOrder(string customerName, string customerAddress, List<string> products, List<int> quantities, double total)
				{
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
