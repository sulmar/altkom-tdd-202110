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
            // Arrange
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();

            mockFileReader
                .Setup(fr => fr.ReadAllText(It.IsAny<string>()))
                .Returns(string.Empty);

            IFileReader fileReader = mockFileReader.Object;

            TrackingService trackingService = new TrackingService(fileReader);

            // Act
            Action act = () => trackingService.Get();

            // Assert
            Assert.Throws<ApplicationException>(act);

        }

        [Fact]
        public void Get_InvalidFile_ShouldThrowsFormatException()
        {
            // Arrange
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();

            mockFileReader
                .Setup(fr => fr.ReadAllText(It.IsAny<string>()))
                .Returns("a");

            IFileReader fileReader = mockFileReader.Object;

            TrackingService trackingService = new TrackingService(fileReader);

            // Act
            Action act = () => trackingService.Get();

            // Assert
            Assert.Throws<FormatException>(act);
        }

        [Fact]
        public void Get_ValidFile_ShouldReturnsLocation()
        {
            // Arrange
            Mock<IFileReader> mockFileReader = new Mock<IFileReader>();

            string json = "{\"Latitude\":54.19438,\"Longitude\":16.17222 }";

            mockFileReader
                .Setup(fr => fr.ReadAllText(It.IsAny<string>()))
                .Returns(json);

            // Tworzy instancję wskazanej atrapy
            IFileReader fileReader = mockFileReader.Object;


            TrackingService trackingService = new TrackingService(fileReader);

            // Act
            var location = trackingService.Get();

            // Assert
            Assert.Equal(54.19438, location.Latitude);
            Assert.Equal(16.17222, location.Longitude);
        }
    }
}
