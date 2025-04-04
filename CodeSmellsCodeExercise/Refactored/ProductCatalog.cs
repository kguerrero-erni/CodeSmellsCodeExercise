using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Refactored
{
    public class ProductCatalog
    {
        private Dictionary<string, double> prices = new Dictionary<string, double>();
        public ProductCatalog()
        {
            prices["Laptop"] = 1200;
            prices["Phone"] = 800;
            prices["Tablet"] = 300;
            prices["Monitor"] = 200;
            prices["Keyboard"] = 50;
        }
        public bool Exists(string productName)
        {
            return prices.ContainsKey(productName);
        }
        public double? GetPrice(string productName)
        {
            return prices[productName];
        }
    }
}
