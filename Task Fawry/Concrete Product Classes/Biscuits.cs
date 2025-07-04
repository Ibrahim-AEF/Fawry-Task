using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Fawry.Models;

namespace Task_Fawry.Concrete_Product_Classes
{
    public class Biscuits : ShippableProduct
    {
        public DateTime ExpiryDate { get; set; }

        public Biscuits(string name, decimal price, int quantity, double weight, DateTime expiryDate)
            : base(name, price, quantity, weight)
        {
            ExpiryDate = expiryDate;
        }

        public override bool IsExpired() => DateTime.Now > ExpiryDate;
    }
}
