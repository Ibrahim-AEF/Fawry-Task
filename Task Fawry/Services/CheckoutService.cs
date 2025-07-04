using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Fawry.Interfaces;
using Task_Fawry.Models;

namespace Task_Fawry.Services
{
    public class CheckoutService
    {
        private readonly IShippingService _shippingService;
        private const decimal ShippingFeePerKg = 10m;

        public CheckoutService(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public void Checkout(Customer customer, Cart cart)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            // Validate cart
            if (!cart.Items.Any())
                throw new InvalidOperationException("Cannot checkout with empty cart");

            // Check product availability and expiry
            foreach (var item in cart.Items)
            {
                if (item.Product.Quantity < item.Quantity)
                    throw new InvalidOperationException($"{item.Product.Name} is out of stock");

                if (item.Product.IsExpired())
                    throw new InvalidOperationException($"{item.Product.Name} has expired");
            }

            // Calculate subtotal
            decimal subtotal = cart.Items.Sum(item => item.Product.Price * item.Quantity);

            // Calculate shipping fees
            var shippableItems = cart.Items
                .Where(item => item.Product is IShippable)
                .Select(item => new
                {
                    Item = (IShippable)item.Product,
                    item.Quantity
                })
                .ToList();

            decimal shippingFees = shippableItems.Sum(item => (decimal)item.Item.GetWeight() * item.Quantity * ShippingFeePerKg);

            decimal totalAmount = subtotal + shippingFees;

            // Check customer balance
            if (customer.Balance < totalAmount)
                throw new InvalidOperationException("Insufficient balance");

            // Process payment
            customer.Balance -= totalAmount;

            // Update product quantities
            foreach (var item in cart.Items)
            {
                item.Product.Quantity -= item.Quantity;
            }

            // Ship items
            var itemsToShip = shippableItems
                .SelectMany(item => Enumerable.Repeat(item.Item, item.Quantity))
                .ToList();

            _shippingService.ShipItems(itemsToShip);

            // Print receipt
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.Product.Price * item.Quantity}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {subtotal}");
            Console.WriteLine($"Shipping {shippingFees}");
            Console.WriteLine($"Amount {totalAmount}");
            Console.WriteLine($"Customer balance after payment: {customer.Balance}");
        }
    }

}
