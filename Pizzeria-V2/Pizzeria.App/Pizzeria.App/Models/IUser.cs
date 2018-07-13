using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.App.Models
{
    public class IUser
    {
        int UserID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int DefaultLocationID { get; set; }
    }
}
