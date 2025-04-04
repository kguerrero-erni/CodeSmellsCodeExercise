using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Interface;
using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise
{
    public class Cart
    {
        private Dictionary<string, int> products = new Dictionary<string, int>(); //name, quantity
        private double totalPrice = 0;
        private IProductDetails _productDetails;

        public Cart(IProductDetails productDetails)
        {
            _productDetails = productDetails;
        }

        public void AddProduct(string product, int quantity)
        {
            if (!IsProductValid(product))
            {
                return;
            }

            if (products.ContainsKey(product))
            {
                products[product] += quantity;
            }
            else
            {
                products.Add(product, quantity);
            }
            Console.WriteLine($"Product {product} added to Cart.");
        }

        public void removeProduct(string product)
        {
            if (!IsProductValid(product))
            {
                return;
            }
            if (!products.ContainsKey(product)) 
            {
                Console.WriteLine($"Can't remove {product}. Product not in Cart.");
            }
            else
            {
                Console.WriteLine($"Product {product} removed from Cart.");
                products.Remove(product);
            }

        }

        public Dictionary<string, int> getProducts() 
        {
            return products;
        }
        public CartList GenerateCartDetails()
        {
            GenerateTotalPrice();
            return new CartList
            {
                ProductList = products,
                TotalPrice = totalPrice
            };
        }
        private void GenerateTotalPrice()
        {
            foreach(string productName in products.Keys)
            {
                totalPrice += (_productDetails.GetPrice(productName) * products[productName]);
            }
        }

        private Boolean IsProductValid(string productName)
        {
            return _productDetails.IsProductValid(productName);
        }
    }
}
