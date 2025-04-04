using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.RefactoredVersion.Data
{
    public interface IDatabase
    {
        void SaveOrder(Order order);
        void DisplayOrders();
    }
}
