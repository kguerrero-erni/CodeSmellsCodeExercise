using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.RefactoredVersion.Data;
namespace CodeSmellsCodeExercise.RefactoredVersion.Services.Interfaces
{
    public interface IOrderValidator
    {
        bool IsValid(Customer customer);
    }
}
