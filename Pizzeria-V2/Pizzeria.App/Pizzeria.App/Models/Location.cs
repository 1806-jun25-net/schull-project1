﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.App.Models
{
    public class Location : ILocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
    }
}
