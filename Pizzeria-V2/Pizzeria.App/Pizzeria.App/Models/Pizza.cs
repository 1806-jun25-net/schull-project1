using System;
using System.Collections.Generic;

namespace Pizzeria.App.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrderPizzaJunction = new HashSet<PizzaOrderPizzaJunction>();
        }

        public int Id { get; set; }
        public bool Pepperoni { get; set; }
        public bool Sausage { get; set; }
        public bool Ham { get; set; }
        public bool Bacon { get; set; }
        public bool Jalapenos { get; set; }
        public bool GreenBellPeppers { get; set; }
        public bool BlackOlives { get; set; }
        public bool Pineapple { get; set; }
        public bool Mushrooms { get; set; }
        public bool Onions { get; set; }

        public ICollection<PizzaOrderPizzaJunction> PizzaOrderPizzaJunction { get; set; }
    }
}
