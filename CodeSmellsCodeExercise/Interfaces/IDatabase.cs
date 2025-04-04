namespace CodeSmellsCodeExercise.Interfaces;

public interface IDatabase
{
    abstract void SaveOrder(ICustomer customer, List<IProduct> orders, double total);
}