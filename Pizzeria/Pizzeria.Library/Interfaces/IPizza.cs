using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Interfaces
{
    public interface IPizza
    {
        ArrayList Toppings { get; set; }
        decimal Price { get; set; }

        void AddTopping();
    }
    public struct Topping
    {
        public string toppingName;
        public int count;
    }
}
