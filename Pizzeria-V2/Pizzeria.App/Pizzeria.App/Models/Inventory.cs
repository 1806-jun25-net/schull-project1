using System;
using System.Collections.Generic;

namespace Pizzeria.App.Models
{
    public partial class Inventory
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

        public Location Location { get; set; }
    }
}
