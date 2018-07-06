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
        public List<Topping> Inventory { get; set; }

        public void DisplayInventory()
        {
            if (Inventory != null)
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"{item.count} x {item.toppingName}");
                }
            }
        }

        public void DeleteInventory()
        {
            Inventory = null;
        }

        public void AddToInventory(string itemName, int itemCount)
        {
            // If inventory has a topping with itemName as the name, do this.
            if (HasTopping(itemName.ToLower()))
            {
                Topping itemInStock = Inventory.FirstOrDefault(x => x.toppingName == itemName.ToLower());
                itemInStock.count += itemCount;
            }
            // If not, create a new topping and add it to the list.
            else
            {
                Inventory.Add(new Topping(itemName.ToLower(), itemCount));
            }
        }

        

        public void RemoveFromInventory(string itemName, int itemCount)
        {
            if (HasTopping(itemName) == true)
            {
                Inventory.Where(x => x.toppingName == itemName);
            }
            //var itemInStock = Inventory.FirstOrDefault(x => x.Name == itemName);
            //if (Inventory.Contains(itemInStock) == true && itemInStock.Count > itemCount)
            //{
            //    if (itemInStock != null && itemInStock.Count >= itemCount)
            //    {
            //        itemInStock.Count -= itemCount;
            //    }
            //    else if (itemInStock.Count < itemCount)
            //    {
            //        Console.WriteLine($"There was not enough {itemInStock.Name} in inventory to pull from stock." +
            //            $" You currently have {itemInStock.Count}.");
            //    }
            //}
            //if (itemInStock.Count == 0)
            //{
            //    Inventory.Remove(itemInStock);
            //}
        }

        private bool HasTopping(string topping)
        {
            // Find an instance of a Topping in the Inventory 
            // where "inventoryTopping.toppingName == topping.toppingName"
            Topping itemInStock = Inventory.FirstOrDefault(x => x.toppingName == topping);
            // Is the topping present in inventory?
            if (itemInStock.toppingName.ToLower() == topping.ToLower())
            {
                return true;
            }
            return false;
        }

        public string InventoryToString()
        {
            throw new NotImplementedException();
        }
    }
}
