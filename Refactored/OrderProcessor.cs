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

		
            public double calculateOrder(Product product){
                double totalPrice = 0;
				for (int i = 0; i < product.ProductNames.Count; i++)
				{
					if (!prices.ContainsKey(product.ProductNames[i]))
					{
						Console.WriteLine($"Unknown product: {product.ProductNames[i]}");
						continue;
					}
					double itemPrice = prices[product.ProductNames[i]] * product.Quantities[i];
					totalPrice += itemPrice;
				}
                return totalPrice;
            }

        


		}