using System;
using CodeSmellsCodeExercise.Interface;
using CodeSmellsCodeExercise.Entities;


namespace CodeSmellsCodeExercise;

public class ProcessingOrder
{

    private readonly ICalculateOrder _calculateOrder;
    private readonly IDiscount _discount;

	private readonly IDatabase _database;


    public ProcessingOrder(IDiscount discount, ICalculateOrder calculateOrder, IDatabase database){
        _discount = discount;
		_calculateOrder = calculateOrder;
		_database = database;
    }
	public void ProcessOrder(CustomerDetails customer,Product product)
			{
				if (string.IsNullOrEmpty(customer.CustomerName) || string.IsNullOrEmpty(customer.CustomerAddress))
				{
					 throw new ArgumentNullException( "The data cannot be null.");
				}
				try
				{   
                      double calculateOrder = _calculateOrder.calculateOrder(product);
                      double discountedPrice = _discount.getDiscount(calculateOrder);

				Console.WriteLine($"Order for {customer.CustomerName} at {customer.CustomerAddress} processed. Total: {discountedPrice}");
					_database.SaveOrder( customer,discountedPrice);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error saving order: " + ex.Message);
				}
			}
}
