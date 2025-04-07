using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise.Actions;

class OrderStore
{
    private readonly List<IProduct>? orders = [];

    public List<IProduct>? GetOrders()
    {
        return orders;
    }

    public void AddProduct(IProduct product)
    {
        if (product.Quantity > 1)
        {
            for (int i = 0; i < product.Quantity; i++)
                orders?.Add(product);

            return;
        }

        orders?.Add(product);
    }

    public void RemoveAllProducts()
    {
        orders?.Clear();
    }
}