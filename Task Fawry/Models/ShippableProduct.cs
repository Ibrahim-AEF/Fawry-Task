using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Fawry.Interfaces;

namespace Task_Fawry.Models
{
    public abstract class ShippableProduct : Product, IShippable
    {
        public double Weight { get; set; } 

        public ShippableProduct(string name, decimal price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
