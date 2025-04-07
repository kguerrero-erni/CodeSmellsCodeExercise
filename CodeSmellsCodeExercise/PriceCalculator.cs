using System.Collections.Generic;
using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise
{
  public class PriceCalculator : IPriceCalculator
  {
    private const int FifteenPercDiscValue = 2000;
    private const int TenPercDiscValue = 1000;

    public double CalculateTotalPrice(List<OrderItem> productNames, List<int> quantities)
    {
      double totalPrice = 0;

      for (int i = 0; i < productNames.Count; i++)
      {
        double itemPrice = (int)productNames[i] * quantities[i];
        totalPrice += itemPrice;
      }

      return ApplyDiscount(totalPrice);
    }

    private double ApplyDiscount(double total)
    {
      if (total > FifteenPercDiscValue)
        return total * 0.85;
      else if (total > TenPercDiscValue)
        return total * 0.90;
      else
        return total;
    }
  }
}
