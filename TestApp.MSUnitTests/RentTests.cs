using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestApp.MSUnitTests
{
    [TestClass]
    public class RentTests
    {
        // Method_Scenario_ExpectedBehavior

        [TestMethod]
        public void CanReturn_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            Rent rent = new Rent();

            // Act
            bool result = rent.CanReturn(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsRentee_ReturnsTrue()
        {
            // Arrange
            User rentee = new User();
            Rent rent = new Rent { Rentee = rentee };            

            // Act
            bool result = rent.CanReturn(rentee);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanReturn_UserIsNotRenteeAndIsNotAdmin_ReturnsFalse()
        {
            // Arrange
            Rent rent = new Rent();

            // Act
            bool result = rent.CanReturn(new User() { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanReturn_UserIsEmpty_ThrowsArgumentNullException()
        {
            // Arrange
            Rent rent = new Rent();

            // Act
            bool result = rent.CanReturn(null);

            // Assert

        }
    }
}
