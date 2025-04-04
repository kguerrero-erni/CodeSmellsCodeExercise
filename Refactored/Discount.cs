using System;
using CodeSmellsCodeExercise.Interface;

namespace CodeSmellsCodeExercise;

public class Discount : IDiscount
{
    public double getDiscount(double totalPrice){
            
		
				if (totalPrice > 2000)
				{
					totalPrice *= 0.85; // Apply 15% discount
				}
				else if (totalPrice > 1000)
				{
					totalPrice *= 0.90; // Apply 10% discount
				}
                
                return totalPrice;
            }
}
