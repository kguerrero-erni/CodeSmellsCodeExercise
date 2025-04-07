using System;

namespace CodeSmellsCodeExercise.Entities;

public class Product
{
    public string ProductNames {get; set;}

    public int Quantities {get ; set;}

    public Product(string productNames, int quantities){
      ProductNames = productNames;
        Quantities = quantities;
    }

    // public void AddItem(string productName, int quantity){
    //     ProductNames.Add(productName);
    //     Quantities.Add(quantity);
    // }
}
