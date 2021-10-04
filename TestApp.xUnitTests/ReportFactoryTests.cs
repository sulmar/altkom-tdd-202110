using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals.Gus;
using Xunit;

namespace TestApp.xUnitTests
{
    public class ReportFactoryTests
    {
        [Fact]
        public void Create_TypeIsF_ShouldReturnsSoleTraderReport()
        {
            // Arrange

            // Act
            var result = ReportFactory.Create("F");

            // Assert
            Assert.IsType<SoleTraderReport>(result); // czy jest konkretnie klasą SoleTraderReport
            Assert.IsAssignableFrom<Report>(result); // czy dziedziczy po klasie Report
        }

        [Theory]
        [InlineData("P")]
        [InlineData("LP")]
        [InlineData("LF")]
        public void Create_TypeIsPOrLPOrLF_ShouldReturnsLegalPersonalityReport(string type)
        {
            // Arrange

            // Act
            var result = ReportFactory.Create(type);

            // Assert
            Assert.IsType<LegalPersonalityReport>(result);
            Assert.IsAssignableFrom<Report>(result);
        }


        [Fact]
        public void Create_TypeIsNotPOrLPOrLFOrF_ShouldThrowsNotSupportedException()
        {
            // Arrange

            // Act
            Action act = () => ReportFactory.Create("A");

            // Assert
            Assert.Throws<NotSupportedException>(act);


        }
    }
}
