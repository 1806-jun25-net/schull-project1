using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Interfaces
{
    public interface IOrder
    {
        string Location { get; set; }
        IUser User { get; set; }
        DateTime OrderTime { get; set; }
        List<IPizza> Pizzas { get; set; }
        decimal Value { get; set; }
    }
}
