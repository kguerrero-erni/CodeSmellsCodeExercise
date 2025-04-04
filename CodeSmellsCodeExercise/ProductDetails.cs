using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Interface;
using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise
{
    public class ProductDetails : IProductDetails
    {
        private Dictionary<string, int> products = new Dictionary<string, int>();

        public ProductDetails()
        {
            //only used to generate sample data. data should be in db
            products.Add("Laptop", 1200);
            products.Add("Phone", 800);
            products.Add("Tablet", 300);
            products.Add("Monitor", 200);
            products.Add("Keyboard", 50);
        }

        public int GetPrice(string productName)
        {
            if (!products.ContainsKey(productName))
            {
                throw new ArgumentException("Item Doesn't Exist");
            }
            return products[productName];
        }

        public Boolean IsProductValid(string productName)
        {
            return products.ContainsKey(productName);
        }


    }
}
