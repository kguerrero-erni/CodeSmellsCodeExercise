using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
    public class Customer
    {
        public string Name { get; }
        public string Address { get; }
        public Customer(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Address);
        }
    }
}
