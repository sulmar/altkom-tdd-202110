using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals;
using Xunit;

namespace TestApp.xUnitTests
{
    public class PrinterTests
    {
        [Fact]
        public void GetLast_MultiContent_ShouldReturnsLastContent()
        {
            // Arrange
            Printer printer = new Printer();

            printer.Print("a");
            printer.Print("b");
            printer.Print("c");

            // Act
            var result = printer.GetLast();

            // Assert
            Assert.Equal("c", result);

        }
    }
}
