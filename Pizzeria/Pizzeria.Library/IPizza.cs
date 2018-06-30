using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library
{
    public interface IPizza
    {
        string[] Toppings { get; set; }
        double Price { get; set; }
    }
}
