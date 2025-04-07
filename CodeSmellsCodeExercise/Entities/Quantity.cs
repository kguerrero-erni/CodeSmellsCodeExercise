using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.Entities
{
  public class Quantity
  {
    public List<int> Quant { get; set; }

    public Quantity(List<int> quant)
    {
      Quant = quant;
    }
  }
}
