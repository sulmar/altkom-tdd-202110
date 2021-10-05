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
        private Mock<IFileReader> mockFileReader;
        private IFileReader fileReader;
        private TrackingService trackingService;

        public TrackingServiceMockTests()
        {
            // Arrange
            mockFileReader = new Mock<IFileReader>();
            fileReader = mockFileReader.Object;
            trackingService = new TrackingService(fileReader);
        }

        [Fact]
        public void Get_EmptyFile_ShouldThrowsApplicationException()
        {
            // Arrange
            mockFileReader
                .Setup(fr => fr.ReadAllText(It.IsAny<string>()))
                .Returns(string.Empty);

            // Act
            Action act = () => trackingService.Get();

            // Assert
            Assert.Throws<ApplicationException>(act);

        }

        [Fact]
        public void Get_InvalidFile_ShouldThrowsFormatException()
        {
            // Arrange
            mockFileReader
                .Setup(fr => fr.ReadAllText(It.IsAny<string>()))
                .Returns("a");

            // Act
            Action act = () => trackingService.Get();

            // Assert
            Assert.Throws<FormatException>(act);
        }

        [Fact]
        public void Get_ValidFile_ShouldReturnsLocation()
        {
            // Arrange
            string json = "{\"Latitude\":54.19438,\"Longitude\":16.17222 }";

            mockFileReader
                .Setup(fr => fr.ReadAllText(It.IsAny<string>()))
                .Returns(json);

            // Act
            var location = trackingService.Get();

            // Assert
            Assert.Equal(54.19438, location.Latitude);
            Assert.Equal(16.17222, location.Longitude);
        }
    }
}
