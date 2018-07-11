using Pizzeria.Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Models
{
    public class Pizza : IPizza
    {
        public int PizzaID { get; set; }
        public decimal Price { get; set; } = 15.00M;
        public Inventory toppings = new Inventory();

        public void ShowPizzaDetails()
        {
            Console.WriteLine(
                $"PizzaID: {PizzaID}\n" + 
                $"Pepperoni: {toppings.Pepperoni == 1}\n" +
                $"Sausage: {toppings.Sausage == 1}\n" +
                $"Ham: {toppings.Ham == 1}\n" +
                $"Bacon: {toppings.Bacon == 1}\n" +
                $"Jalapenos: {toppings.Jalapenos == 1}\n" +
                $"Green Bell Peppers: {toppings.GreenBellPeppers == 1}\n" +
                $"Black Olives: {toppings.BlackOlives == 1}\n" +
                $"Pineapple: {toppings.Pineapple == 1}\n" +
                $"Mushrooms: {toppings.Mushrooms == 1}\n" +
                $"Onions: {toppings.Onions == 1}\n" +
                $"Current Price: {Price.ToString("C2")}\n");
        }

        public override string ToString()
        {
            string pizzaString = $"PizzaID: {PizzaID}, " +
                $"{toppings.ToString()}, " +
                $"Price: {Price.ToString("C2")}";
            Console.WriteLine(pizzaString);
            return pizzaString;
        }
    }
}
