using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise.Actions;

public class OrderProcessor(IDatabase database)
{
    private double totalPrice = 0;

    private readonly IDatabase _database = database;

    public void ProcessOrder(ICustomer customer, List<IProduct>? orders)
    {
        if (string.IsNullOrEmpty(customer.FullName) || string.IsNullOrEmpty(customer.Address))
            throw new ArgumentNullException("Invalid customer details");

        if (orders?.Count() == 0)
            throw new ArgumentNullException("Order is empty, Cannot proceed.");

        foreach (var order in orders!)
            totalPrice += order.Price;

        ApplyDiscount(totalPrice);

        Console.WriteLine($"Order for {customer.FullName} at {customer.Address} processed. Total: {totalPrice}");

        _database.SaveOrder(customer, orders, totalPrice);
    }

    public void ApplyDiscount(double price)
    {
        if (price > 2000)
        {
            totalPrice *= 0.85; // Apply 15% discount
        }
        else if (price > 1000)
        {
            totalPrice *= 0.90; // Apply 10% discount
        }
    }
}