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

        public void AddTopping(Ingredient topping)
        {
            try
            {
                Toppings.Add(topping);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ERROR: {ex} - You cannot add nothing as a topping.");
            }
            finally
            {
                Price += 1.00M;
            }
        }

        public void RemoveTopping(Ingredient topping)
        {
            try
            {
                this.Toppings.Contains(topping);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"ERROR: {ex} - The topping you attempted to remove was not found on your pizza.");
            }
            finally
            {
                Toppings.Remove(topping);
                Price -= 1.00M;
            }
        }

        public string ToString(Pizza pizza)
        {
            string result = "A pizza with ";
            foreach(var topping in pizza.Toppings)
            {
                result += $"{topping}, ";
            }
            result += $"all worth {pizza.Price}";
            return result;
        }
    }
}
