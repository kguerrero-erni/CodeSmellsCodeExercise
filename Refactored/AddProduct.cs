using System;
using CodeSmellsCodeExercise.Entities;

namespace CodeSmellsCodeExercise;

public class AddProduct
{
    public List<Product> _productItems;

    public AddProduct(){
          _productItems = new List<Product>();
    }
    public void AddItem(string productName, int quantity){
        var newProductItem = new Product(productName, quantity);
        _productItems.Add(newProductItem);
    }

    public List<Product> GetItems(){
        return _productItems;
    }
}
