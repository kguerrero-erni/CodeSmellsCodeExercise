using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Models
{
    public class OrderDetails
    {
        public Customer Customer { get; set; }
        public CartList CartList { get; set; }
        public int DiscountedPrice { get; set; }
    }
}
