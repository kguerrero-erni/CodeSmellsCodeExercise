using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using CodeSmellsCodeExercise.RefactoredVersion;
using CodeSmellsCodeExercise.RefactoredVersion.Data;
using CodeSmellsCodeExercise.RefactoredVersion.Domain.DiscountStrategy;
using CodeSmellsCodeExercise.RefactoredVersion.Services;
using CodeSmellsCodeExercise.RefactoredVersion.Services.Interfaces;

namespace CodeSmellsCodeExercise.RefactoredVersion
{
    public class RefactoredOrderProcessor(IOrderValidator orderValidator, ITotalCostCalculator totalCostCalculator, IDatabase database)
    {   
        public readonly IOrderValidator OrderValidator = orderValidator;
        public readonly ITotalCostCalculator totalCostCalculator = totalCostCalculator;
        public IDatabase database = database;

        private bool ValidateCustomer(Customer customer)
        {
            if (!OrderValidator.IsValid(customer))
            {
                Console.WriteLine("Invalid customer details.");
                return false;
            }
            return true;
        }

        private bool CalculateTotal(Order order, out double total)
        {
            try
            {
                total = totalCostCalculator.CalculateTotalPrice(order.OrderItems);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating total price: {ex.Message}");
                total = 0;
                return false;
            }
        }

        private double ApplyDiscount(double total)
        {
            return DiscountStrategyContext.GetDiscountStrategy(total).ApplyDiscount(total);
        }

        private void LogOrderSummary(Customer customer, double price)
        {
            Console.WriteLine($"Order for {customer.Name} at {customer.Address} processed. Total: {price}");
        }

        private void SaveOrder(Order order)
        {
            try
            {
                database.SaveOrder(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving order: " + ex.Message);
            }
        }

        public void ProcessOrder(Order order)
        {
            if (!ValidateCustomer(order.Customer)) return;

            if (!CalculateTotal(order, out double totalPrice)) return;

            double finalPrice = ApplyDiscount(totalPrice);

            LogOrderSummary(order.Customer, finalPrice);

            SaveOrder(order);
        }
    }

}


