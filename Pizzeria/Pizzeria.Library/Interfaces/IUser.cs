using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Interfaces
{
    public interface IUser
    {
        int UserID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int DefaultLocationID { get; set; }
    }
}
