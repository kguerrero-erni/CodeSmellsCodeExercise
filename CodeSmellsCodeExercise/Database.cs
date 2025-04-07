using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise
{
  public class Database : IDatabase
  {
    public void SaveOrder(string customerName, double totalPrice)
    {
      if (string.IsNullOrEmpty(customerName) || totalPrice <= 0)
      {
        throw new ArgumentException("Invalid order details.");
      }
      Console.WriteLine("Order saved to database.");
    }
  }
}
