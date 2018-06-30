using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string DefaultLocation { get; set; }
        DateTime LastOrder { get; set; }
    }
}
