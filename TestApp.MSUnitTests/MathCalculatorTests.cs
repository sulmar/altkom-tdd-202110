using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.MSUnitTests
{
    [TestClass]
    public class MathCalculatorTests
    {
        // Method_Scenario_ExpectedBehavior

        private MathCalculator mathCalculator;

        [TestInitialize] // wywoływane dla każdej metody testującej
        public void Setup()
        {
            // Arrange
            mathCalculator = new MathCalculator();
        }

        [TestMethod]
        public void Add_PassedArguments_ReturnsSumOfAguments()
        {
            // Act
            var result = mathCalculator.Add(1, 2);

            // Assert
            Assert.AreEqual( 3, result);
        }

        [TestMethod]
        public void Max_FirstArgumentIsGreater_ReturnsFirstArgument()
        {
            // Act
            var result = mathCalculator.Max(2, 1);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Max_SecondArgumentIsGreater_ReturnsSecondArgument()
        {
            // Act
            var result = mathCalculator.Max(1, 2);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Max_ArgumentsAreEqual_ReturnsFirstArgument()
        {
            // Act
            var result = mathCalculator.Max(1, 1);

            // Assert
            Assert.AreEqual(1, result);
        }

        
        [DataTestMethod]
        [DataRow(2, 1, 2, DisplayName = "First argument is greater")]
        [DataRow(1, 2, 2, DisplayName = "Second argument is greater")]
        [DataRow(1, 1, 1, DisplayName = "Arguments are equal")]
        public void Max_ValidArguments_ReturnsMaxArgument(int first, int second, int expected)
        {
            // Act
            var result = mathCalculator.Max(first, second);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
