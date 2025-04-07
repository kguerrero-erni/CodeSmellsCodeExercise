using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise.Products;

public class MonitorScreen : IProduct
{
    public string Name;
    public int Price;
    public int Quantity;

    public MonitorScreen()
    {
        Name = "MonitorScreen";
        Price = 200;
        Quantity = 1;
    }

    string IProduct.Name => Name;
    int IProduct.Price => Price;
    int IProduct.Quantity => Quantity;

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }
}