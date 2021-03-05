using lab1_1;
using System;
using Xunit;

namespace Lab1_Tests
{
        public class WalletTest
        {
            [Fact]
            public void Test1()
            {
                //Arrange
                var wallet = new Wallet { Name = "masha", Currency = "usd", InitialBalance = 200.0, Description = "ygjgg", UserId = 3 };


          
                //Act
                var actual = wallet.Validate();

                //Assert
                Assert.True(actual);
            }
        }
    }
