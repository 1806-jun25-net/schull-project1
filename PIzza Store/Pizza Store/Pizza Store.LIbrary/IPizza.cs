using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Store.LIbrary
{
    public interface IPizza
    {
        ArrayList Toppings { get; set; }
        decimal Price { get; set; }

        void AddTopping(string ingredientName);
    }

    public struct Ingredient
    {
        public string title;
        public int count;
    }
}
