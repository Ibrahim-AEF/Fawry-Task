using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Fawry.Models
{
    public abstract class NonShippableProduct : Product
    {
        public NonShippableProduct(string name, decimal price, int quantity)
            : base(name, price, quantity)
        {
        }
    }
}
