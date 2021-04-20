using lab1_1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Lab1_Tests
{
    public class CategoryTest
    {

        //public Category(Guid userGuid, string name, string description, ColorWrapper colorWrapper, Icon image, Guid guid)
        [Fact]
        public void ValidateCategory()
        {
            //Arrange
            Category cat1 = new Category(Guid.NewGuid(), "business", "description", new ColorWrapper(System.Drawing.Color.Red), null, Guid.NewGuid());

            //Act
            var actual = cat1.Validate();

            //Assert
            Assert.True(actual);
        }


        [Fact]
        public void ValidateBadName()
        {
            //Arrange
            Category cat2 = new Category(Guid.NewGuid(), " ", "description", new ColorWrapper(System.Drawing.Color.Black), null, Guid.NewGuid());

            //Act
            var actual = cat2.Validate();

            //Assert
            Assert.False(actual);
        }





    }
}