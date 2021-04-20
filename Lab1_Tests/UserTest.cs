using lab1_1;
using System;
using System.Drawing;
using Xunit;

namespace Lab1_Tests
{


    public class UserTest
    {

        [Fact]
        public void ValidateValid()
        {
            //Arrange
            User user1 = new User(Guid.NewGuid(), "Romanenko", "Mariia", "masha110202@gmail.com", "romasha");

            //Act
            var actual = user1.Validate();

            //Assert
            Assert.True(actual);

        }

        [Fact]
        public void ValidateBadLastName()
        {
            //Arrange
            User user2 = new User(Guid.NewGuid(), "", "Mariia", "masha110202@gmail.com", "romasha");

            //Act
            var actual = user2.Validate();

            //Assert
            Assert.False(actual);

        }

        [Fact]
        public void ValidateBadEmail()
        {
            //Arrange
            User user3 = new User(Guid.NewGuid(), "Romanenko", "Mariia", "", "romasha");

            //Act
            var actual = user3.Validate();

            //Assert
            Assert.False(actual);

        }

        [Fact]
        public void ValidateBadLogin()
        {
            //Arrange
            User user4 = new User(Guid.NewGuid(), "Romanenko", "Mariia", "masha110202@gmail.com", "");

            //Act
            var actual = user4.Validate();

            //Assert
            Assert.False(actual);

        }



        [Fact]
        public void FullNameTest()
        {
            //Arrange
            User masha = new User(Guid.NewGuid(), "Romanenko", "Mariia", "masha110202@gmail.com", "romasha");
            var expected = "Romanenko, Mariia";

            //Act
            var actual = masha.FullName;

            //Assert
            Assert.True(expected == actual);
        }



    }
}