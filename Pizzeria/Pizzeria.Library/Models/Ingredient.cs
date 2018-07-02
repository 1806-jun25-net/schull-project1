using Pizzeria.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Models
{
    public class Ingredient : ITopping
    {
        public Ingredient(string item, int quantity)
        {
        }

        public string Name { get; set; }
        public int Count { get; set; }

        public override string ToString() => $"{Name}, {Count}";
    }
}
