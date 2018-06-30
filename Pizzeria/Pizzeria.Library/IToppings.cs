using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library
{
    public interface IToppings
    {
        string Topping { get; set; }
        int InventoryCount { get; set; }
    }
}
