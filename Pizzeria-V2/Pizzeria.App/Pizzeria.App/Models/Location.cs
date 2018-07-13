using System;
using System.Collections.Generic;

namespace Pizzeria.App.Models
{
    public partial class Location
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int Id { get; set; }
        public string LocationName { get; set; }

        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
