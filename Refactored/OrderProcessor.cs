using System;
using CodeSmellsCodeExercise.Interface;
using CodeSmellsCodeExercise.Entities;


namespace CodeSmellsCodeExercise;

public class OrderProcessor : ICalculateOrder
		{
			private Dictionary<string, double> prices = new Dictionary<string, double>();

			public OrderProcessor()
			{
				prices["Laptop"] = 1200;
				prices["Phone"] = 800;
				prices["Tablet"] = 300;
				prices["Monitor"] = 200;
				prices["Keyboard"] = 50;
			}

		
            public double calculateOrder(AddProduct product)
        {
            double totalPrice = 0;
            foreach (var item in product.GetItems())
            {
                if (!prices.ContainsKey(item.ProductNames))
                {
                    Console.WriteLine($"Unknown product: {item.ProductNames}");
                    continue;
                }
                double itemPrice = prices[item.ProductNames] * item.Quantities;
                totalPrice += itemPrice;
            }
            return totalPrice;
        }
    

        


		}