using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Interfaces
{
    public interface ITopping
    {
        string Name { get; set; }
        int Count { get; set; }
    }
}
