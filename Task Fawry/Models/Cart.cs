using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Fawry.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; } = new List<CartItem>();

        public void Add(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive", nameof(quantity));

            if (product.Quantity < quantity)
                throw new InvalidOperationException($"Not enough stock for {product.Name}. Available: {product.Quantity}");

            var existingItem = Items.FirstOrDefault(item => item.Product == product);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem(product, quantity));
            }
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
