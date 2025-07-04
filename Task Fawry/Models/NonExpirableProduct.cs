using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Fawry.Models
{
    public class NonExpirableProduct : Product
    {
        public NonExpirableProduct(string name, decimal price, int quantity)
            : base(name, price, quantity)
        {
        }

        public override bool IsExpired()
        {
            return false;
        }
    }
}
