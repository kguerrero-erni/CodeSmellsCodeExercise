using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise.Interface
{
    public interface IProductDetails
    {

        public int GetPrice(string productName);
        public Boolean IsProductValid(string productName);
    }
}
