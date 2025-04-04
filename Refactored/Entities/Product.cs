using System;

namespace CodeSmellsCodeExercise.Entities;

public class Product
{
    public List<string> ProductNames {get; set;}

    public List<int> Quantities {get ; set;}

    public Product(List<string> productNames, List<int> quantities){
        ProductNames = productNames;
        Quantities = quantities;
    }
}
