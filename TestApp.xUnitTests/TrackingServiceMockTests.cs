using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Mocking;
using Xunit;

namespace TestApp.xUnitTests
{
    // Install-Package Moq
    public class TrackingServiceMockTests
    {
        [Fact]
        public void Get_EmptyFile_ShouldThrowsApplicationException()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Get_InvalidFile_ShouldThrowsFormatException()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Get_ValidFile_ShouldReturnsLocation()
        {
            // Arrange
            // Mock<

            // TrackingService trackingService = new TrackingService()

            // Act

            // Assert
        }
    }
}
