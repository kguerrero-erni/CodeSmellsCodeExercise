using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise.Interface
{
    public interface ICart
    {
        void AddProduct(string product, int quantity);
        void RemoveProduct(string product);
        Dictionary<string, int> GetProducts();
        public CartList GenerateCartDetails();
        void GenerateTotalPrice();
    }
}
