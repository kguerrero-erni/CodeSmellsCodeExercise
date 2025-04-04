using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise.Interface
{
    public interface IDatabaseRepository
    {
        public void SaveOrder(OrderDetails orderDetails);
    }
}
