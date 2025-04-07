using System;
using CodeSmellsCodeExercise.Interface;

namespace CodeSmellsCodeExercise;

public class Discount : IDiscount
{
    public double getDiscount(double totalPrice){
            
		
				if (totalPrice > 2000)
				{
					totalPrice *= 0.85; 
				}
				else if (totalPrice > 1000)
				{
					totalPrice *= 0.90;
				}
                
                return totalPrice;
            }
}
