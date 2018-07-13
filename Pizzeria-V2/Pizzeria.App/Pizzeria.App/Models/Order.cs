using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.App.Models
{
    public class Order : IOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime TimePlaced { get; set; }
        public decimal OrderValue { get; set; } = 0.00M;
    }
}
