using Pizzeria.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pizzeria.Library.Models
{
    public class Location : ILocation
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public Inventory LocationInventory = new Inventory();
        public List<IOrder> OrderHistory { get; set; }
        //
        //  Fix the inventory stuff in Location!
        //
        public void AddOrderToHistory(Order order)
        {
            OrderHistory.Add(order);
        }

        public void AddToInventory(string itemName, int itemCount)
        {
            // For each possible item in the inventory. Otherwise, no such item exists.
            switch (itemName)
            {
                case "pepperoni":
                    LocationInventory.Pepperoni += itemCount;
                    break;
                case "sausage":
                    LocationInventory.Sausage += itemCount;
                    break;
                case "ham":
                    LocationInventory.Ham += itemCount;
                    break;
                case "bacon":
                    LocationInventory.Bacon += itemCount;
                    break;
                case "jalapenos":
                    LocationInventory.Jalapenos += itemCount;
                    break;
                case "green bell peppers":
                    LocationInventory.GreenBellPeppers += itemCount;
                    break;
                case "black olives":
                    LocationInventory.BlackOlives += itemCount;
                    break;
                case "pineapple":
                    LocationInventory.Pineapple += itemCount;
                    break;
                case "mushrooms":
                    LocationInventory.Mushrooms += itemCount;
                    break;
                case "onions":
                    LocationInventory.Onions += itemCount;
                    break;
                default:
                    throw new ArgumentException($"Incorrect input: no such topping as {itemName}");
            }
        }

        public void RemoveFromInventory(string itemName, int itemCount)
        {
            switch (itemName)
            {
                case "pepperoni":
                    if (LocationInventory.Pepperoni > itemCount)
                    {
                        LocationInventory.Pepperoni -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "sausage":
                    if (LocationInventory.Sausage > itemCount)
                    {
                        LocationInventory.Sausage -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "ham":
                    if (LocationInventory.Ham > itemCount)
                    {
                        LocationInventory.Ham -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "bacon":
                    if (LocationInventory.Bacon > itemCount)
                    {
                        LocationInventory.Bacon -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "jalapenos":
                    if (LocationInventory.Jalapenos > itemCount)
                    {
                        LocationInventory.Jalapenos -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "green bell peppers":
                    if (LocationInventory.GreenBellPeppers > itemCount)
                    {
                        LocationInventory.GreenBellPeppers -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "black olives":
                    if (LocationInventory.BlackOlives > itemCount)
                    {
                        LocationInventory.BlackOlives -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "pineapple":
                    if (LocationInventory.Pineapple > itemCount)
                    {
                        LocationInventory.Pineapple -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "mushrooms":
                    if (LocationInventory.Mushrooms > itemCount)
                    {
                        LocationInventory.Mushrooms -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                case "onions":
                    if (LocationInventory.Onions > itemCount)
                    {
                        LocationInventory.Onions -= itemCount;
                    }
                    else
                    {
                        Console.WriteLine($"You can't have a negative count of something!\n");
                    }
                    break;
                default:
                    throw new ArgumentException($"Incorrect input: no such topping as {itemName}\n");
            }
        }
    }
}
