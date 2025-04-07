using System.Collections.Generic;

namespace CodeSmellsCodeExercise.Interfaces
{
  public interface IPriceCalculator
  {
    double CalculateTotalPrice(List<OrderItem> productNames, List<int> quantities);
  }
}
