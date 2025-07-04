using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Fawry.Interfaces
{
    public interface IShippingService
    {
        void ShipItems(List<IShippable> items);
    }
}
