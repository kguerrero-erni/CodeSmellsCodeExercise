using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise.Database;

public class DatabaseConnection : IDatabase
{
    public void SaveOrder(ICustomer customer, List<IProduct> orders, double total)
    {
        if (string.IsNullOrEmpty(customer.FullName) || string.IsNullOrEmpty(customer.Address) || total <= 0)
            throw new ArgumentException("Invalid order details.");

        Console.WriteLine("Order saved in the database");
    }
}