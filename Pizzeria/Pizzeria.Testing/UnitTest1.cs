using System;
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
    }
}
