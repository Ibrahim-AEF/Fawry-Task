using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Fawry.Models;

namespace Task_Fawry.Concrete_Product_Classes
{
    public class MobileScratchCard : NonShippableProduct
    {
        public MobileScratchCard(string name, decimal price, int quantity)
            : base(name, price, quantity)
        {
        }

        public override bool IsExpired() => false;
    }
}
