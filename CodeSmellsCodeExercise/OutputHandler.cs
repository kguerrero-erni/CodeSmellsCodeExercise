using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise
{
  public class OutputHandler : IOutputHandler
  {
    public void HandleOutput(string customerName, string customerAddress, double totalPrice, IDatabase database)
    {
      Console.WriteLine($"Order for {customerName} at {customerAddress} processed. Total: {totalPrice}");

      try
      {
        database.SaveOrder(customerName, totalPrice);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error saving order: " + ex.Message);
      }
    }
  }
}
