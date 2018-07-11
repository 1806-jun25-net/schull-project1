using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Models
{
    public struct Inventory
    {
        public int InventoryID { get; set; }
        public int Pepperoni { get; set; }
        public int Sausage { get; set; }
        public int Ham { get; set; }
        public int Bacon { get; set; }
        public int Jalapenos { get; set; }
        public int GreenBellPeppers { get; set; }
        public int BlackOlives { get; set; }
        public int Pineapple { get; set; }
        public int Mushrooms { get; set; }
        public int Onions { get; set; }

        public void Display()
        {
            Console.WriteLine($"Your Inventory ID: {InventoryID}\n" +
                $"Pepperoni: {Pepperoni}\n" +
                $"Sausage: {Sausage}\n" +
                $"Ham: {Ham}\n" +
                $"Bacon: {Bacon}\n" +
                $"Jalapenos: {Jalapenos}\n" +
                $"Green Bell Peppers: {GreenBellPeppers}\n" +
                $"Black Olives: {BlackOlives}\n" +
                $"Pineapple: {Pineapple}\n" +
                $"Mushrooms: {Mushrooms}\n" +
                $"Onions: {Onions}\n");
        }

        public override string ToString()
        {
            string inventoryString = $"InventoryID: {InventoryID}, " +
                $"Pepperoni: {Pepperoni}, " +
                $"Sausage: {Sausage}, " +
                $"Ham: {Ham}, " +
                $"Bacon: {Bacon}, " +
                $"Jalapenos: {Jalapenos}, " +
                $"GreenBellPeppers: {GreenBellPeppers}, " +
                $"BlackOlives: {BlackOlives}, " +
                $"Pineapple: {Pineapple}, " +
                $"Mushrooms: {Mushrooms}, " +
                $"Onions: {Onions}";
            return inventoryString;
        }

        public void EmptyInventory()
        {
            Pepperoni = 0;
            Sausage = 0;
            Ham = 0;
            Bacon = 0;
            Jalapenos = 0;
            GreenBellPeppers = 0;
            BlackOlives = 0;
            Pineapple = 0;
            Mushrooms = 0;
            Onions = 0;
        }
    }
}
