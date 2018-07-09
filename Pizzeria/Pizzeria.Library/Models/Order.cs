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
        ILocation IOrder.Location { get; set; }
        public IUser User { get; set; }
        public DateTime OrderTime { get; set; }
        public List<IPizza> Pizzas { get; set; }
        public decimal Value { get; set; } = 0.00M;

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
                if(Pizzas.Count < 12)
                {
                    Pizzas.Add(pizza);
                    Value = RecalculateValue();
                }
                else
                {
                    Console.WriteLine("There are already 12 pizzes in your order, you can't add any more!");
                }
            }
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
    }
}
