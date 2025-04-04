using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.RefactoredVersion.Data;
using CodeSmellsCodeExercise.RefactoredVersion.Services.Interfaces;

namespace CodeSmellsCodeExercise.RefactoredVersion.Services
{
    public class OrderValidator: IOrderValidator
    {
        public bool IsValid(Customer Customer)
        {
            return !string.IsNullOrEmpty(Customer.Name) && !string.IsNullOrEmpty(Customer.Address);
        }
    }
}
