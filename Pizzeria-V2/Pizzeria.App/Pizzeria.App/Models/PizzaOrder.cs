using System;
using System.Collections.Generic;

namespace Pizzeria.App.Models
{
    public partial class PizzaOrder
    {
        public PizzaOrder()
        {
            PizzaOrderPizzaJunction = new HashSet<PizzaOrderPizzaJunction>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime TimePlaced { get; set; }
        public decimal OrderValue { get; set; }

        public Location Location { get; set; }
        public Users User { get; set; }
        public ICollection<PizzaOrderPizzaJunction> PizzaOrderPizzaJunction { get; set; }
    }
}
