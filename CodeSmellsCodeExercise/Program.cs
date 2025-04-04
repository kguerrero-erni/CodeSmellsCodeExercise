using CodeSmellsCodeExercise.Actions;
using CodeSmellsCodeExercise.Database;
using CodeSmellsCodeExercise.Interfaces;
using CodeSmellsCodeExercise.Products;

namespace CodeSmellsCodeExercise;

internal class Program
{
	static void Main(string[] args)
	{
		Customer customer1 = new("Rodel Crisosto", "Quezon City");
		OrderStore orderStore = new(); // Acts like shopping cart

		Laptop laptop = new();
		Phone phone = new();

		laptop.SetQuantity(2);

		orderStore.AddProduct(laptop);
		orderStore.AddProduct(phone);

		var customerInfo = customer1.GetCustomerInformation();
		var orders = orderStore.GetOrders();


		IDatabase database = new DatabaseConnection();

		OrderProcessor orderProcessor = new(database);
		orderProcessor.ProcessOrder(customerInfo, orders);
	}
}