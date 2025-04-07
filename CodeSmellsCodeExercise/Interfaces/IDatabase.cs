namespace CodeSmellsCodeExercise.Interfaces
{
  public interface IDatabase
  {
    void SaveOrder(string customerName, double totalPrice);
  }
}
