using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library
{
    public interface ILocation
    {
        string LocationName { get; set; }
        List<IToppings> Inventory { get; set; }
    }
    bool CheckOrderValidity(IOrder order)
    {

    }
}
