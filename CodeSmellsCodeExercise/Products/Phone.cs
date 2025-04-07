using CodeSmellsCodeExercise.Interfaces;

namespace CodeSmellsCodeExercise.Products;

public class Phone : IProduct
{
    public string Name;
    public int Price;
    public int Quantity;

    public Phone()
    {
        Name = "Phone";
        Price = 800;
        Quantity = 1;
    }

    string IProduct.Name => Name;
    int IProduct.Price => Price;
    int IProduct.Quantity => Quantity;

    public void setQuantity(int quantity)
    {
        Quantity = quantity;
    }
}