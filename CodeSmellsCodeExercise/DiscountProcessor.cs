using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise
{
  public class DiscountProcessor
  {
    private int fifteenPercDiscValue = 2000;
    private int tenPercDiscValue = 1000;
    private double totalPrice;

    public DiscountProcessor(double total)
    {
      this.totalPrice = total;
    }

    public double CheckDisc()
    {
      if (totalPrice > fifteenPercDiscValue)
      {
        return totalPrice *= 0.85; // Apply 15% discount
      }
      else if (totalPrice > tenPercDiscValue)
      {
        return totalPrice *= 0.90; // Apply 10% discount
      }
      else
      {
        return totalPrice;
      }
    }


  }
}
