using Pizzeria.Library;
using Pizzeria.Library.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Pizzeria.Testing
{
    public class UnitTest1
    {
        //[Fact]
        //public void OrderHasItemLimit(Order order)
        //{
        //    var pizzaList = new List<Pizza>;
        //    for(int i = 0; i <= 12; i++) // should run 13 times
        //    {
        //        order.AddPizza(new Pizza());
        //    }
        //    Assert.Throws<IndexOutOfRangeException>;
        //}
        [Fact]
        public void OrderIsNotNull()
        {
            Order order = new Order();
        }
    }
}
