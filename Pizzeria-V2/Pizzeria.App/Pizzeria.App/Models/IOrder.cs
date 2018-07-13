using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.App.Models
{
    interface IOrder
    {
        int Id { get; set; }
        int UserId { get; set; }
        int LocationId { get; set; }
        DateTime TimePlaced { get; set; }
        decimal OrderValue { get; set; }
    }
}
