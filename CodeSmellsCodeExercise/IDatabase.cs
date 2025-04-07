using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
    internal interface IDatabase
    {
        void SaveOrder(Order order);
    }
}
