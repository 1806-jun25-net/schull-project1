using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Interfaces
{
    public interface ILocation
    {
        string LocationName { get; set; }
        List<Topping> Inventory { get; set; }

        void DisplayInventory();
        string InventoryToString();
    }
}
