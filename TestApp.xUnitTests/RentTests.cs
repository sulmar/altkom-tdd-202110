using System;
using Xunit;

namespace TestApp.xUnitTests
{
    public class RentTests
    {
        private Rent rent;

        public RentTests()
        {
            // Arrange
            rent = new Rent();
        }

        // Method_Scenario_ExpectedBehavior

        [Fact]
        public void CanReturn_UserIsAdmin_ReturnsTrue()
        {
            // Act
            bool result = rent.CanReturn(new User { IsAdmin = true });

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanReturn_UserIsRentee_ReturnsTrue()
        {
            // Arrange
            User rentee = new User();
            rent.Rentee = rentee;

            // Act
            bool result = rent.CanReturn(rentee);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanReturn_UserIsNotRenteeAndIsNotAdmin_ReturnsFalse()
        {
            // Act
            bool result = rent.CanReturn(new User() { IsAdmin = false });

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CanReturn_UserIsEmpty_ThrowsArgumentNullException()
        {
            // Act
            Action act = () => rent.CanReturn(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
