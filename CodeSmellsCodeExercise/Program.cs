using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace CodeSmellsCodeExercise
{
    internal class Program
    {
      static void Main(string[] args)
      {

        OrderProcessor orderProcessor = new OrderProcessor("Jane Doe", "California", new List<OrderItem> { OrderItem.Laptop, OrderItem.Phone }, new List<int> { 1, 3 });
			  orderProcessor.ProcessOrder();
        orderProcessor = new OrderProcessor("John Doe", "New York", new List<OrderItem> { OrderItem.Tablet, OrderItem.Monitor, OrderItem.Keyboard }, new List<int> { 1, 1, 1 });
			  orderProcessor.ProcessOrder();
        orderProcessor = new OrderProcessor("Sam Smith", "New York", new List<OrderItem> { OrderItem.Tablet, OrderItem.Monitor, OrderItem.Laptop }, new List<int> { 2, 1, 3 });
        orderProcessor.ProcessOrder();
        orderProcessor = new OrderProcessor("Ben&Ben", "Manila", new List<OrderItem> { OrderItem.Tablet, OrderItem.Monitor}, new List<int> { 2, 1, 3 });
        orderProcessor.ProcessOrder();
      }

    
    class OrderProcessor
    {
      private double totalPrice;
      private string customerName;
      private string customerAddress;
      private List<OrderItem> productNames;
      private List<int> quantities;

    

      public OrderProcessor(string customerName, string customerAddress, List<OrderItem> productNames, List<int> quantities)
      {
        
        this.customerName = customerName;
        this.customerAddress = customerAddress;
        this.productNames = productNames;
        this.quantities = quantities;
      }
      void SetTotalPrice(double totalPrice)
      {
        this.totalPrice = totalPrice;
      }


      public void ProcessOrder()
      {
        NameAddressIsNullOrEmpty();

        CalculateTotalPrice();
    
        OutputHandler();


        void NameAddressIsNullOrEmpty()
        {
          if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerAddress))
          {
            Console.WriteLine("Invalid customer details.");
            return;
          }

        }

        void CalculateTotalPrice()
        {
          double totalPrice = 0;
          for (int i = 0; i < productNames.Count; i++)
          {
            double itemPrice = (int)productNames[i] * quantities[i];
            totalPrice += itemPrice;
           }

          var discountProcessor = new DiscountProcessor(totalPrice);
          totalPrice = discountProcessor.CheckDisc();
          SetTotalPrice(totalPrice);

          

        }

        void OutputHandler()
        {
          Console.WriteLine($"Order for {customerName} at {customerAddress} processed. Total: {totalPrice}");

          try
          {
            SaveOrder();
          }
          catch (Exception ex)
          {
            Console.WriteLine("Error saving order: " + ex.Message);
          }

        }

        void SaveOrder()
        {
    
          if (string.IsNullOrEmpty(customerName) || totalPrice <= 0)
          {
            throw new ArgumentException("Invalid order details.");
          }
          Console.WriteLine("Order saved to database.");
        }

        


    }
   

    }
  
    
    


    }
}
