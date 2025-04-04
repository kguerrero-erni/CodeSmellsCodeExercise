namespace CodeSmellsCodeExercise;

class OrderRepository : IOrderRepository {
    public void SaveOrder(Order order)
    {
        if (order == null || order.totalPrice <= 0)
		{
			throw new ArgumentException("Invalid order details.");
		}
		Console.WriteLine("Order saved to database.");
    }
}