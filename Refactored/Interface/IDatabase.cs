using CodeSmellsCodeExercise.Entities;

namespace CodeSmellsCodeExercise.Interface;

public interface IDatabase
{
        void SaveOrder(CustomerDetails customer, double total);
}
