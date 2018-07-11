using Pizzeria.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzeria.Library.Models
{
    public class Order : IOrder
    {
        public int OrderID { get; set; }
        public ILocation Location { get; set; }
        public IUser User { get; set; }
        public DateTime OrderTime { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public decimal Value { get; set; } = 0.00M;

        public void ViewOrder()
        {
            Console.WriteLine("Your order is currently as follows:");
            foreach(var pizza in Pizzas)
            {
                pizza.ShowPizzaDetails();
            }

            string p = "";
            if (Pizzas.Count == 1)
            {
                p = "pizza";
            }
            else
            {
                p = "pizzas";
            }
            Console.WriteLine($"You are ordering {Pizzas.Count} {p}, for a grand total of {Value.ToString("C2")}\n");
        }

        public void RemovePizza(int pizzaIdNumber)
        {
            if(Pizzas.ElementAt(pizzaIdNumber) != null)
            {
                // Remove pizza at index
                Pizzas.RemoveAt(pizzaIdNumber);
                // Remove all null pizzas from the order
                /* Clarification: If we just remove a pizza from the order, then that index will just be null.
                   This would cause some issues with the order count, since there would then be x-1 pizzas, but
                   the program would still just think there are x pizzas. Gotta be safe! */
                Pizzas = Pizzas.Where(pizza => pizza != null).ToList();
                foreach(var pizza in Pizzas)
                {
                    pizza.PizzaID = Pizzas.IndexOf(pizza);
                }
                Value = RecalculateValue();
            }
            else
            {
                Console.WriteLine("There are no pizzas in this order!");
            }
        }

        public void DeleteOrder()
        {
            Pizzas.Clear();
            Value = 0.00M;
        }

        public decimal RecalculateValue()
        {
            decimal result = 0.00M;
            foreach(var pizza in Pizzas)
            {
                result += pizza.Price;
            }
            return result;
        }
        
        public override string ToString()
        {
            string result = $"OrderID: {OrderID}, " +
                $"LocationID: {Location.LocationID}, " +
                $"UserID: {User.UserID}, " +
                $"OrderTime: {OrderTime}, Pizzas Ordered:(";
            foreach(var item in Pizzas)
            {
                result += $"{item.ToString()},";
            }
            result += $") Value: {Value},";
            return result;
        }
    }
}
