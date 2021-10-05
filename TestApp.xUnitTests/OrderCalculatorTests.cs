using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Refactoring;
using Xunit;

namespace TestApp.xUnitTests
{
    public class OrderCalculatorTests
    {
        // Method_Scenario_ExpectedBehavior

        private DateTime beginHour = DateTime.MinValue.AddHours(8);
        private DateTime endHour = DateTime.MinValue.AddHours(15);
        private decimal percentage = 0.1m;

        private OrderCalculator orderCalculator;
        private Customer customer;

        public OrderCalculatorTests()
        {
            orderCalculator = new OrderCalculator(beginHour.TimeOfDay, endHour.TimeOfDay, percentage);
            customer = new Customer("A", "B");
        }

        [Fact]
        public void CalculateDiscount_BeforeBeginHour_ShouldNotReturnsDiscount()
        {
            // Arrange

            Order order = new Order(beginHour.AddMinutes(-1), customer);
            order.TotalAmount = 100;

            // Act
            var result = orderCalculator.CalculateDiscount(order);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateDiscount_AfterEndHour_ShouldNotReturnsDiscount()
        {
            // Arrange
            Order order = new Order(endHour.AddMinutes(1), customer);
            order.TotalAmount = 100;

            // Act
            var result = orderCalculator.CalculateDiscount(order);

            // Assert
            Assert.Equal(0, result);
        }

        //[Fact]
        //public void CalculateDiscount_DuringHappyHours_ShouldNotReturnsDiscount()
        //{
        //    throw new NotImplementedException();
        //}

        [Fact]
        public void CalculateDiscount_AfterBeginHour_ShouldReturnsDiscount()
        {
            // Arrange
            Order order = new Order(beginHour, customer);
            order.TotalAmount = 100;

            // Act
            var result = orderCalculator.CalculateDiscount(order);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void CalculateDiscount_BeforeEndHour_ShouldReturnsDiscount()
        {
            // Arrange
            Order order = new Order(endHour.AddMinutes(-1), customer);
            order.TotalAmount = 100;

            var result = orderCalculator.CalculateDiscount(order);

            // Assert
            Assert.Equal(10, result);

        }

        [Fact]
        public void CalculateDiscount_EmptyOrder_ShouldThrowArgumentNullException()
        {
            // Arrange

            // Act
            Action act = () => orderCalculator.CalculateDiscount(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
