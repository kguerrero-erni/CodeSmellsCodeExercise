using System;

namespace CodeSmellsCodeExercise.Entities;

public interface IDiscountRule
{
    bool IsApplicable(double totalPrice);
    double ApplyDiscount(double totalPrice);
}
