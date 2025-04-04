using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmellsCodeExercise.CodeSmellsComments
{
  internal class CodeSmells
  {
    
   
      void Main(string[] args)
      {
        OrderProcessor orderProcessor = new OrderProcessor();
        // Data Clumps
        orderProcessor.ProcessOrder("Jane Doe", "California", new List<string> { "Laptop", "Phone" }, new List<double> { 1200, 800 }, new List<int> { 1, 2 });
        orderProcessor.ProcessOrder("John Doe", "New York", new List<string> { "Tablet", "Monitor", "Keyboard" }, new List<double> { 300, 200, 50 }, new List<int> { 1, 1, 1 });

        Console.ReadLine();
      }

      class OrderProcessor
      {
        // Tight Coupling
        private Dictionary<string, double> prices = new Dictionary<string, double>();

        public OrderProcessor()
        {
          prices["Laptop"] = 1200;
          prices["Phone"] = 800;
          prices["Tablet"] = 300;
          prices["Monitor"] = 200;
          prices["Keyboard"] = 50;
        }
        // Long Methods
        public void ProcessOrder(string customerName, string customerAddress, List<string> productNames, List<double> productPrices, List<int> quantities)
        {
          // Specify Conditional
          if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerAddress))
          {
            Console.WriteLine("Invalid customer details.");
            return;
          }


          // CalculateTotalPrice
          double totalPrice = 0;
          for (int i = 0; i < productNames.Count; i++)
          {
            // IsValidProduct
            if (!prices.ContainsKey(productNames[i]))
            {
              Console.WriteLine($"Unknown product: {productNames[i]}");
              continue;
            }
            double itemPrice = prices[productNames[i]] * quantities[i];
            totalPrice += itemPrice;
          }
          // DiscountProcessor class with fifteenPercDiscValue, tenPercDiscValue for readability

          if (totalPrice > 2000)
          {
            totalPrice *= 0.85; // Apply 15% discount
          }

          else if (totalPrice > 1000)
          {
            totalPrice *= 0.90; // Apply 10% discount
          }
          // Create OutputHandler

          Console.WriteLine($"Order for {customerName} at {customerAddress} processed. Total: {totalPrice}");

          try
          {
            Database.SaveOrder(customerName, customerAddress, productNames, quantities, totalPrice);
          }
          catch (Exception ex)
          {
            Console.WriteLine("Error saving order: " + ex.Message);
          }
        }

        class Database
        {
          // Data Clumps, just do within the class
          public static void SaveOrder(string customerName, string customerAddress, List<string> products, List<int> quantities, double total)
          {
            // Specify Conditional
            if (string.IsNullOrEmpty(customerName) || total <= 0)
            {
              throw new ArgumentException("Invalid order details.");
            }
            Console.WriteLine("Order saved to database.");
          }
        }
      }
    }
  }


