using lab1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lab1_Tests
{
    public class TransactionTest
    {
        [Fact]
        public void ValidateTransaction()
        {
            //Arrange
            Category cat1 = new Category(Guid.NewGuid(), "business", "description", new ColorWrapper(System.Drawing.Color.White), null, Guid.NewGuid());


            Transaction tr1 = new Transaction(Guid.NewGuid(), -20.8m, Currency.EUR, cat1, "something", System.DateTime.Now, Guid.NewGuid());

            //Act
            var actual = tr1.Validate();

            //Assert
            Assert.True(actual);
        }



        [Fact]
        public void ValidateBadCategory()
        {
            //Arrange
            Transaction invalid = new Transaction(Guid.NewGuid(), -100m, Currency.USD, null, "something", System.DateTime.Now, Guid.NewGuid());

            //Act
            var actual = invalid.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateBadAmount()
        {
            //Arrange
            Category cat3 = new Category(Guid.NewGuid(), "business", "description here...", new ColorWrapper(System.Drawing.Color.White), null, Guid.NewGuid());

            Transaction invalid = new Transaction(Guid.NewGuid(), 0.0m, Currency.UAH, null, "something", System.DateTime.Now, Guid.NewGuid());

            //Act
            var actual = invalid.Validate();

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void ValidateCurrency()
        {
            //Arrange
            Category cat4 = new Category(Guid.NewGuid(), "business", "description here...", new ColorWrapper(System.Drawing.Color.White), null, Guid.NewGuid());
            Transaction invalid = new Transaction(Guid.NewGuid(), -30m, null, cat4, "something", System.DateTime.Now, Guid.NewGuid());

            //Act
            var actual = invalid.Validate();

            //Assert
            Assert.False(actual);
        }





    }
}
