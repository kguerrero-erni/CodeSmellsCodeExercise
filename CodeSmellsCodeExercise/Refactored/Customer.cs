using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Refactored
{
    public class Customer(string Name, string Address)
    {
        public string name { get; set; } = Name;
        public string address { get; set; } = Address;
    }
}
