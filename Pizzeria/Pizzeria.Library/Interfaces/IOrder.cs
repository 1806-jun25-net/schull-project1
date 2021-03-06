﻿using Pizzeria.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Interfaces
{
    public interface IOrder
    {
        int OrderID { get; set; }
        ILocation Location { get; set; }
        IUser User { get; set; }
        DateTime OrderTime { get; set; }
        List<Pizza> Pizzas { get; set; }
        decimal Value { get; set; }
    }
}
