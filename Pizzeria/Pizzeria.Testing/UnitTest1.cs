using System;
using System.Collections.Generic;
using Xunit;

namespace Pizzeria.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void UserShowNameShouldShowFullName(User user)
        {
            // arrange
            user.FirstName = "Wesley";
            user.LastName = "Schull";
            var expected = "Wesley Schll";
            // act
            var actual = user.ShowName();
            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OrderHasItemLimit(Order order)
        {
            var pizzaArray = new Pizza[12];
            for(int i = 0; i <= 12; i++) // should run 13 times
            {
                pizzaArray[i] = new Pizza();
            }
            Assert.Throws<IndexOutOfRangeException>;
        }
    }
}
