using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Interfaces
{
    public interface ILocation
    {
        int LocationID { get; set; }
        string LocationName { get; set; }
        HashSet<string> Inventory { get; set; }

        void DisplayInventory();
        string InventoryToString();
    }
}
