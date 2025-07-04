using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Fawry.Models;

namespace Task_Fawry.Concrete_Product_Classes
{
    public class TV : ShippableProduct
    {
        public TV(string name, decimal price, int quantity, double weight)
            : base(name, price, quantity, weight)
        {
        }

        public override bool IsExpired() => false;
    }
}
