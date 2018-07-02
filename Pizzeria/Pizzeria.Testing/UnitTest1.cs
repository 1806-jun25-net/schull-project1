using Pizzeria.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace Pizzeria.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void OrderHasItemLimit(IOrder order)
        {
            var pizzaList = new List<Pizza>;
            for(int i = 0; i <= 12; i++) // should run 13 times
            {
                pizzaList.Add(new Pizza);
            }
            Assert.Throws<IndexOutOfRangeException>;
        }
    }
}
