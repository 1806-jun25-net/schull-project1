using System;
using System.Collections.Generic;

namespace Pizzeria.App.Models
{
    public partial class Users
    {
        public Users()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PreferredLocationId { get; set; }
        public bool Employee { get; set; }

        public ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
