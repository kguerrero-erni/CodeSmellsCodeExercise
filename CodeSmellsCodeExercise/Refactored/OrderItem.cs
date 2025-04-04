using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Refactored
{
    public class OrderItem(string name, int quantity)
    {
        public string name { get; set; } = name;
        public int quantity { get; set; } = quantity;
    }


}
