using System;

namespace CodeSmellsCodeExercise.Entities;

public class Product
{
    public List<string> ProductNames {get; set;}

    public List<int> Quantities {get ; set;}

    public Product(){
      ProductNames = new List<string>();
        Quantities = new List<int>();
    }

    public void AddItem(string productName, int quantity){
        ProductNames.Add(productName);
        Quantities.Add(quantity);
    }
}
