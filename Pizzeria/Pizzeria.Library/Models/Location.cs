using Pizzeria.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pizzeria.Library.Models
{
    public class Location : ILocation
    {
        public string LocationName { get; set; }
        public List<ITopping> Inventory { get; set; }

        public void DisplayInventory()
        {
            if (Inventory != null)
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"{item.Count} x {item.Name}");
                }
            }
        }

        public void DeleteInventory()
        {
            Inventory = null;
        }

        public void AddToInventory(string itemName, int itemCount)
        {
            var itemInStock = Inventory.FirstOrDefault(x => x.Name == itemName);
            if (itemInStock != null)
            {
                itemInStock.Count += itemCount;
            }
        }

        public void RemoveFromInventory(string itemName, int itemCount)
        {
            var itemInStock = Inventory.FirstOrDefault(x => x.Name == itemName);
            if (Inventory.Contains(itemInStock) == true && itemInStock.Count > itemCount)
            {
                if (itemInStock != null && itemInStock.Count >= itemCount)
                {
                    itemInStock.Count -= itemCount;
                }
                else if (itemInStock.Count < itemCount)
                {
                    Console.WriteLine($"There was not enough {itemInStock.Name} in inventory to pull from stock." +
                        $" You currently have {itemInStock.Count}.");
                }
            }
            if (itemInStock.Count == 0)
            {
                Inventory.Remove(itemInStock);
            }
        }
    }
}
