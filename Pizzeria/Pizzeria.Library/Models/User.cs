using Pizzeria.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Library.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;

        public User(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultLocationID { get; set; }
    }
}
