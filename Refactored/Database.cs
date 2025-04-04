using CodeSmellsCodeExercise.Entities;
using CodeSmellsCodeExercise.Interface;

namespace CodeSmellsCodeExercise;

public class Database : IDatabase
{
	public void SaveOrder(CustomerDetails customer, double total)
				{
					if (string.IsNullOrEmpty(customer.CustomerName) || total <= 0)
					{
						throw new ArgumentException("Invalid order details.");
					}
					Console.WriteLine("Order saved to database.");
				}
}
