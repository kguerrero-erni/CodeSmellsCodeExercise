using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise.Products;

public class Keyboard : IProduct
{
    public string Name;
    public int Price;
    public int Quantity;

    public Keyboard()
    {
        Name = "Keyboard";
        Price = 50;
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