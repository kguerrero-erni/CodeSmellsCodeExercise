namespace CodeSmellsCodeExercise.Interfaces
{
  public interface IOutputHandler
  {
    void HandleOutput(string customerName, string customerAddress, double totalPrice, IDatabase database);
  }
}
