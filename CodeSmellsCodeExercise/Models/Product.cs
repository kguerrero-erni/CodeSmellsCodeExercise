namespace CodeSmellsCodeExercise;

class Product {
    public string productNames {get;}
    public int quantities {get;}

    public Product(string productName, int quantity) {
        productNames = productName;
        quantities = quantity;
    }
}