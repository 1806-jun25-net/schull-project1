using System;
using System.Collections.Generic;

namespace Pizzeria.App.Models
{
    public partial class PizzaOrderPizzaJunction
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public PizzaOrder Order { get; set; }
        public Pizza Pizza { get; set; }
    }
}
