using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.App.Models
{
    interface ILocation
    {
        int Id { get; set; }
        string LocationName { get; set; }
    }
}
