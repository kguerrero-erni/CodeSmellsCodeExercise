using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise.Products;

public class Laptop : IProduct
{
    public string Name;
    public int Price;
    public int Quantity;

    public Laptop()
    {
        Name = "Laptop";
        Price = 1200;
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