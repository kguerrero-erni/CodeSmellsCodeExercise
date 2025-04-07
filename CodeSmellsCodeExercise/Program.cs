using CodeSmellsCodeExercise.Entities;
using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise
{
  internal class Program
  {
    static void Main(string[] args)
    {
      IPriceCalculator priceCalculator = new PriceCalculator();
      IInputHandler inputHandler = new InputHandler();
      IOutputHandler outputHandler = new OutputHandler();
      IDatabase database = new Database();

      User janeCal = new User("Jane Doe", "California");
      Quantity janeQ = new Quantity(new List<int> { 1, 3 });
      var janeProd = new List<OrderItem> { OrderItem.Laptop, OrderItem.Phone };

      var janeProcessor = new OrderProcessor(janeCal, janeProd, janeQ, priceCalculator, inputHandler, outputHandler, database);
      janeProcessor.ProcessOrder();

      User johnNY = new User("John Doe", "New York");
      Quantity johnQ = new Quantity(new List<int> { 1, 1, 1 });
      var johnProd = new List<OrderItem> { OrderItem.Tablet, OrderItem.Monitor, OrderItem.Keyboard };

      var johnProcessor = new OrderProcessor(johnNY, johnProd, johnQ, priceCalculator, inputHandler, outputHandler, database);
      johnProcessor.ProcessOrder();
    }

    class OrderProcessor
    {
      private double totalPrice;
      private string customerName;
      private string customerAddress;
      private List<OrderItem> productNames;
      private List<int> quantities;

      private readonly IPriceCalculator priceCalculator;
      private readonly IInputHandler inputHandler;
      private readonly IOutputHandler outputHandler;
      private readonly IDatabase database;

      public OrderProcessor(User customer, List<OrderItem> productNames, Quantity quantities,
                            IPriceCalculator priceCalculator,
                            IInputHandler inputHandler,
                            IOutputHandler outputHandler,
                            IDatabase database)
      {
        this.customerName = customer.Name;
        this.customerAddress = customer.Address;
        this.productNames = productNames;
        this.quantities = quantities.Quant;

        this.priceCalculator = priceCalculator;
        this.inputHandler = inputHandler;
        this.outputHandler = outputHandler;
        this.database = database;
      }
      Boolean NameAddressIsNullOrEmpty()
      {
        if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerAddress))
        {
          Console.WriteLine("Invalid customer details.");
          return false;
        }
        return true;

      }

      public void ProcessOrder()
      {
        if (!NameAddressIsNullOrEmpty())
        {
          return;
        }

        totalPrice = priceCalculator.CalculateTotalPrice(productNames, quantities);
        outputHandler.HandleOutput(customerName, customerAddress, totalPrice, database);
      }
    }
  }
}
