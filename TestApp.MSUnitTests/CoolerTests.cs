using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals;

namespace TestApp.MSUnitTests
{
    [TestClass]
    public class CoolerTests
    {
        [TestMethod]
        public void Cooler_WhenCreated_SetsIsEnabledFalse()
        {
            // Act
            Cooler cooler = new Cooler();

            // Assert
            Assert.IsFalse(cooler.IsEnabled);
        }

        [TestMethod]
        public void Start_WhenCalled_SetsIsEnabledTrue()
        {
            // Arrange
            Cooler cooler = new Cooler();

            // Act
            cooler.Start();

            // Assert
            Assert.IsTrue(cooler.IsEnabled);
        }

        [TestMethod]
        public void Stop_WhenCalled_SetsIsEnabledFalse()
        {
            // Arrange
            Cooler cooler = new Cooler();
            cooler.Start();

            // Act
            cooler.Stop();

            // Assert
            Assert.IsFalse(cooler.IsEnabled);

        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void ChangeMode_WhenDisabled_ThrowsInvalidOperationException()
        {
            // Arrange
            Cooler cooler = new Cooler();

            // Act
            cooler.ChangeMode();
        }

        [TestMethod]
        public void Cooler_WhenCreated_SetsIsCoolingMode()
        {
            // Act
            Cooler cooler = new Cooler();

            // Assert
            Assert.AreEqual(CoolerModes.Cooling, cooler.Mode);
        }

        [TestMethod]
        public void ChangeMode_CoolingWhenCalled_SetsHeatingMode()
        {
            // Arrange
            Cooler cooler = new Cooler();
            cooler.Start();

            // Act
            cooler.ChangeMode();

            // Assert
            Assert.AreEqual(CoolerModes.Heating, cooler.Mode);

        }

        [TestMethod]
        public void ChangeMode_HeatingWhenCalled_SetsCoolingMode()
        {
            // Arrange
            Cooler cooler = new Cooler(); // -> Cooling
            cooler.Start();  
            cooler.ChangeMode();  // => Heating

            // Act
            cooler.ChangeMode();

            // Assert
            Assert.AreEqual(CoolerModes.Cooling, cooler.Mode);
        }



    }
}
