using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSmellsCodeExercise.Interface;
using CodeSmellsCodeExercise.Models;

namespace CodeSmellsCodeExercise
{
    public class OrderProcessor
    {
        private readonly IDatabaseRepository _repository;
        private Customer customer;
        private CartList cartList;
        private double discountedPrice;

        public OrderProcessor(Customer customer ,CartList cartList, IDatabaseRepository database)
        {
            _repository = database;
            this.customer = customer;
            this.cartList = cartList;
        }

        public void ProcessOrder()
        {
            if (!IsCustomerValid())
            {
                Console.WriteLine("Invalid customer details.");
                return;
            }
            discountedPrice = ApplyDiscount();

            Console.WriteLine($"Order for {customer.Name} at {customer.Address} processed. Total: {cartList.TotalPrice}. Final Discounted Price: {discountedPrice}");

            try
            {
                _repository.SaveOrder(new OrderDetails { Customer = customer, CartList = cartList });
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException occured in Saving Order");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred in Saving Order: " + e.Message);
            }

        }

        private double ApplyDiscount()
        {
            double totalPrice = cartList.TotalPrice;
            if (totalPrice > 2000)
            {
                totalPrice *= 0.85; // Apply 15% discount
            }
            else if (totalPrice > 1000)
            {
                totalPrice *= 0.90; // Apply 10% discount
            }
            return totalPrice;
        }

        private Boolean IsCustomerValid()
        {
            if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Address))
            {
                return false;
            }
            return true;
        }
    }
}
