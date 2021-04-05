using lab1_1;
using System;
using System.Collections.Generic;
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

        [Fact]
        public void TransactionCount()
        {
            //Arrange
            var wallet = new Wallet { Name = "masha", Currency = "usd", InitialBalance = 200, Description = "ygjgg", UserId = 3, IsShared = true };
            var category1 = new Category() { Name = "food", Color = "red", Description = "mmmmmm" };
            var category2 = new Category() { Name = "food", Color = "green", Description = "ccccc" };
            List < Category > categories = new List<Category>();
            categories.Add(category1);
            categories.Add(category2);

            var transaction1 = new Transaction() { Sum = 25, Currency = "euro", Category = category1, Date = new DateTime(2021, 3, 1, 7, 0, 0) };
            var transaction2 = new Transaction() { Sum = 30, Currency = "usd", Category = category2, Date = new DateTime(2021, 3, 3, 9, 0, 0) };
           // var transaction3 = new Transaction() { Sum = -10, Currency = "euro", Category = category1, Date = new DateTime(2021, 3, 1, 7, 0, 0) };
           // var transaction4 = new Transaction() { Sum = -45, Currency = "usd", Category = category2, Date = new DateTime(2021, 6, 5, 12, 0, 0) };
            wallet.addTransaction(transaction1);
            wallet.addTransaction(transaction2);
            //Act            
            var result1 = wallet.countMonthTransactionsPlus();
            
            var expected1 = transaction1.Sum + transaction2.Sum;
        
            //Assert
            Assert.Equal(result1,expected1);
           // Assert.Equal(result2, expected2);
        }
    }
    }
