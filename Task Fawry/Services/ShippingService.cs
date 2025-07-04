using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Fawry.Interfaces;

namespace Task_Fawry.Services
{
    public class ShippingService : IShippingService
    {
        public void ShipItems(List<IShippable> items)
        {
            if (items == null || !items.Any())
                return;

            Console.WriteLine("** Shipment notice **");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetName()} {item.GetWeight()}kg");
            }

            double totalWeight = items.Sum(i => i.GetWeight());
            Console.WriteLine($"Total package weight {totalWeight}kg");
        }
    }
}
