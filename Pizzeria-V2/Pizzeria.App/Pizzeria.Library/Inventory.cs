using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library
{
    public class Inventory
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
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

        public Inventory(int locationId, int pepperoni, int sausage, int ham, int bacon, int jalapenos, int greenBellPeppers,
            int blackOlives, int pineapple, int mushrooms, int onions)
        {
            LocationId = locationId;
            Pepperoni = pepperoni;
            Sausage = sausage;
            Ham = ham;
            Bacon = bacon;
            Jalapenos = jalapenos;
            GreenBellPeppers = greenBellPeppers;
            BlackOlives = blackOlives;
            Pineapple = pineapple;
            Mushrooms = mushrooms;
            Onions = onions;
        }
    }

}
