using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Mocking;
using Xunit;

namespace TestApp.xUnitTests
{

    // Fake - udawać
    // Mock - duszek / zjawa / atrapa

    public class FakeValidFile : IFileReader
    {
        // Koszalin lat: 54.19438 lng: 16.17222
        public string ReadAllText(string path)
        {
            return "{\"Latitude\":54.19438,\"Longitude\":16.17222 }";
        }
    }

    public class FakeEmptyFile : IFileReader
    {
        public string ReadAllText(string path)
        {
            return string.Empty;
        }
    }

    public class FakeInvalidFile : IFileReader
    {
        public string ReadAllText(string path)
        {
            return "a";
        }
    }

    public class TrackingServiceTests
    {
        [Fact]
        public void Get_EmptyFile_ShouldThrowsApplicationException()
        {
            // Arrange
            TrackingService trackingService = new TrackingService(new FakeEmptyFile());

            // Act
            Action act = () => trackingService.Get();

            // Assert
            Assert.Throws<ApplicationException>(act);
        }

        [Fact]
        public void Get_InvalidFile_ShouldThrowsFormatException()
        {
            // Arrange
            TrackingService trackingService = new TrackingService(new FakeInvalidFile());

            // Act
            Action act = () => trackingService.Get();

            // Assert
            Assert.Throws<FormatException>(act);

        }

        [Fact]
        public void Get_ValidFile_ShouldReturnsLocation()
        {
            // Arrange
            TrackingService trackingService = new TrackingService(new FakeValidFile());

            // Act
            var location = trackingService.Get();

            // Assert
            Assert.Equal(54.19438, location.Latitude);
            Assert.Equal(16.17222, location.Longitude);

        }
    }
}
