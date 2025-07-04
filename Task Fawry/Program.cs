using Task_Fawry.Concrete_Product_Classes;
using Task_Fawry.Models;
using Task_Fawry.Services;

namespace Task_Fawry
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Setup products
            var cheese = new Cheese("Cheese", 100m, 10, 0.4, DateTime.Now.AddDays(7));
            var biscuits = new Biscuits("Biscuits", 150m, 5, 0.7, DateTime.Now.AddDays(14));
            var tv = new TV("TV", 2000m, 3, 15.0);
            var scratchCard = new MobileScratchCard("Mobile Scratch Card", 50m, 100);

            // Setup services
            var shippingService = new ShippingService();
            var checkoutService = new CheckoutService(shippingService);

            // Create customer
            var customer = new Customer("John Doe", 5000m);

            // Test case 1: Example from requirements
            try
            {
                var cart1 = new Cart();
                cart1.Add(cheese, 2);
                cart1.Add(biscuits, 1);
                checkoutService.Checkout(customer, cart1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n---\n");

            // Test case 2: With TV and scratch card
            try
            {
                var cart2 = new Cart();
                cart2.Add(tv, 1);
                cart2.Add(scratchCard, 3);
                checkoutService.Checkout(customer, cart2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n---\n");

            // Test case 3: Edge cases
            try
            {
                // Try to checkout with empty cart
                var cart3 = new Cart();
                checkoutService.Checkout(customer, cart3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                // Try to buy more than available
                var cart4 = new Cart();
                cart4.Add(cheese, 100); // Only 10 available (2 already sold in first test case)
                checkoutService.Checkout(customer, cart4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                // Try with insufficient balance
                var poorCustomer = new Customer("Jane Doe", 100m);
                var cart5 = new Cart();
                cart5.Add(tv, 1); // TV costs 2000
                checkoutService.Checkout(poorCustomer, cart5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
