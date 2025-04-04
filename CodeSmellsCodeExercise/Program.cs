using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using CodeSmellsCodeExercise.Entities;
namespace CodeSmellsCodeExercise
{
    internal class Program
    {
      static void Main(string[] args)
      {
        User janeCal = new User("Jane Doe", "California");
        Quantity janeQ = new Quantity(new List<int> { 1, 3 });
        var janeProd = new List<OrderItem> { OrderItem.Laptop, OrderItem.Phone };
        OrderProcessor orderProcessor = new OrderProcessor(janeCal, janeProd, janeQ );
			  orderProcessor.ProcessOrder();

        User johnNY = new User("John Doe", "New York");
        Quantity johnQ = new Quantity(new List<int> { 1, 1, 1 });
        var johnProd = new List<OrderItem> { OrderItem.Tablet, OrderItem.Monitor, OrderItem.Keyboard };
        orderProcessor = new OrderProcessor(johnNY, johnProd, johnQ);
        orderProcessor.ProcessOrder();


      }

    
    class OrderProcessor
    {
      private double totalPrice;
      private string customerName;
      private string customerAddress;
      private List<OrderItem> productNames;
      private List<int> quantities;

    

      public OrderProcessor(User customer, List<OrderItem> productNames, Quantity quantities)//string customerName, string customerAddress,
      {
        
        this.customerName = customer.Name;
        this.customerAddress = customer.Address;
        this.productNames = productNames;
        this.quantities = quantities.Quant;
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
