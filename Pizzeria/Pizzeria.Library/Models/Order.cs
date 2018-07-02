using Pizzeria.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzeria.Library.Models
{
    public class Order : IOrder
    {
        public DateTime OrderTime { get; set; }
        public string Location { get; set; }
        public IUser User { get; set; }
        public decimal Value { get; set; } = 0.00M;
        public List<IPizza> Pizzas { get; set; }

        public void ViewOrder(Order order)
        {
            Console.WriteLine("Your order is currently as follows:");
            foreach(var pizza in order.Pizzas)
            {
                Console.WriteLine($"Pizza {order.Pizzas.IndexOf(pizza) + 1}: {pizza.ToString()}");
            }
            Console.WriteLine($"You are ordering {order.Pizzas.Count} pizzas, for a grand total of {order.Value.ToString("{0:C2")}");
        }

        public void AddPizza(Pizza pizza)
        {
            if(pizza != null)
            {
                Pizzas.Add(pizza);
            }
        }

        public void RemovePizza(int pizzaIdNumber)
        {
            // Remove pizza at index ID-1 (since lists are 0-based)
            Pizzas.RemoveAt(pizzaIdNumber - 1);
            // Remove all null pizzas from the order
            /* Clarification: If we just remove a pizza from the order, then that index will just be null.
               This would cause some issues with the order count, since there would then be x-1 pizzas, but
               the program would still just think there are x pizzas. Gotta be safe! */
            Pizzas = Pizzas.Where(pizza => pizza != null).ToList();
        }

        public void DeleteOrder()
        {
            Pizzas.Clear();
            Value = 0.00M;
        }
    }
}
