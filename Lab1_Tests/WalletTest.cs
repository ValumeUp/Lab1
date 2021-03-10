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
                var wallet = new Wallet { Name = "masha", Currency = "usd", InitialBalance = 200, Description = "ygjgg", UserId = 3 };


          
                //Act
                var actual = wallet.Validate();

                //Assert
                Assert.True(actual);
            }

        [Fact]
        public void CustomerCounterTest()
        {
            //Arrange
            var wallet = new Wallet();
            var wallet1 = new Wallet();
            var wallet2 = new Wallet();

            //Act            

            //Assert
            Assert.Equal(wallet1.Id, wallet.Id + 1);
            Assert.Equal(wallet2.Id, wallet1.Id + 1);
        }
    }
    }
