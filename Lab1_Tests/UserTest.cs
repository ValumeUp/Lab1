using lab1_1;
using System;
using Xunit;

namespace Lab1_Tests
{
    public class UserTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var  user1= new User { Name = "David", Surname="Black", Email="davBl@gmail.com" };
            var actual = user1.Validate();
            Assert.True(actual);
            Assert.Equal(user1.Guid, 1);
            var wallet = new Wallet { Name = "masha", Currency = "usd", InitialBalance = 200, Description = "ygjgg", UserId = 1 };
            user1.Cards.Add(wallet);
            var str=user1.Show();
            var str2 = "User 1: David, Black, Email: davBl@gmail.com";
            Assert.Equal(str, str2);

        }
    }
}