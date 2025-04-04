using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            ProductDetails productDetails = new ProductDetails();

            Customer customer = new Customer
            {
                Name = "MJ",
                Address = "Cavite"
            };

            Cart customerCart = new Cart(productDetails);
            customerCart.AddProduct("Laptop",1);
            customerCart.AddProduct("Phone", 1);
            customerCart.AddProduct("Tablet", 1);

            OrderProcessor orderProcessor = new OrderProcessor(customer, customerCart.GenerateCartDetails(), db);
            orderProcessor.ProcessOrder();

        }
        
        
    }
}
