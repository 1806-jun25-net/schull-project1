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
    }
    public struct Topping
    {
        public Topping(string name, int count)
        {
            this.toppingName = name;
            this.count = count;
        }
        public string toppingName;
        public int count;
    }
}
