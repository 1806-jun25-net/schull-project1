using Pizzeria.Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Models
{
    public class Pizza : IPizza
    {
        public ArrayList Toppings { get; set; }
        public decimal Price { get; set; } = 15.00M;

        public void AddTopping(string topping)
        {
            // If input is not null or empty, add to Toppings and increase price
            if(topping != null && topping != "")
            {
                Toppings.Add(topping);
                Price += 1.00M;
            }
        }

        public void RemoveTopping(string topping)
        {
            // If input is not null or empty
            if(topping != null && topping != "")
            {
                // If Toppings contains input, remove that topping and decrease price
                if (Toppings.Contains(topping))
                {
                    Toppings.Remove(topping);
                    Price -= 1.00M;
                }
            }
        }

        public void ShowPizzaDetails()
        {
            string output = "This pizza has ";
            // Adds each topping to the string followed by a comma for formatting
            foreach (var item in Toppings)
            {
                output += $"{item}, ";
            }
            output += $"and is worth {Decimal.ToOACurrency(Price)}";
        }

        public string ToString()
        {
            string output = "";
            foreach(var item in Toppings)
            {
                output += $"{item} ";
            }
            output += $": {Price}";
            return output;
        }
    }
}
