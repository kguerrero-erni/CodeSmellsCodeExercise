using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Models
{
    public class CartList
    {
        public Dictionary<string, int>? ProductList { get; set; }
        public double TotalPrice { get; set; }
    }
}
