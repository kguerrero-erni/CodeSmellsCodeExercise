namespace CodeSmellsCodeExercise;
class OrderProcessor : IOrderProcess
{
    private readonly IDiscount _discount;
    private readonly IOrderRepository _orderRepository;
    private readonly Dictionary<string, double> _prices;
    public OrderProcessor(IDiscount discount, IOrderRepository orderRepository)
    {
        _discount = discount;
        _orderRepository = orderRepository;
        
        _prices = new Dictionary<string, double>
        {
            {"Laptop", 1200},
			{"Phone", 800},
			{"Tablet", 300},
			{"Monitor", 200},
			{"Keyboard", 50},
        };


    }

    public void ProcessOrder(Order order)
    {
        double total = 0;

        foreach(var product in order.products) {
            if(!_prices.ContainsKey(product.productNames)) {
                Console.WriteLine($"Unknown product: {product.productNames}");
                continue;

            }
            total += _prices[product.productNames]  * product.quantities;
        }
        total = _discount.ApplyDiscount(total);
        order.setTotalPrice(total);

        Console.WriteLine($"Order for {order.customer.customerName} at {order.customer.customerAddress} processed. Total: {total}");
            
        try
		{
			_orderRepository.SaveOrder(order);
        }
		catch (Exception ex)
		{
			Console.WriteLine("Error saving order: " + ex.Message);
		}
    }

}