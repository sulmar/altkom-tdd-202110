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

    public class DeviceServiceTests
    {
        private Mock<IWebClient> mockWebClient;
        private DeviceService deviceService;

        public DeviceServiceTests()
        {
            this.mockWebClient = new Mock<IWebClient>();
            this.deviceService = new DeviceService( mockWebClient.Object);
        }

        [Fact]
        public void GetStatus_Ready_ShouldReturnsReadyStatus()
        {
            // Arrange
            mockWebClient
                .Setup(wc => wc.DownloadString(It.IsAny<string>()))
                .Returns("<status>0</status>");

            // Act
            var result  = deviceService.GetStatus(1);

            // Assets
            Assert.Equal(DeviceStatus.Ready, result);
        }

        [Fact]
        public void GetStatus_Cooling_ShouldReturnsReadyStatus()
        {
            // Arrange
            mockWebClient
                .Setup(wc => wc.DownloadString(It.IsAny<string>()))
                .Returns("<status>1</status>");

            // Act
            var result = deviceService.GetStatus(1);

            // Assets
            Assert.Equal(DeviceStatus.Cooling, result);
        }

        [Fact]
        public void GetStatus_Heating_ShouldReturnsReadyStatus()
        {
            // Arrange
            mockWebClient
                .Setup(wc => wc.DownloadString(It.IsAny<string>()))
                .Returns("<status>2</status>");

            // Act
            var result = deviceService.GetStatus(1);

            // Assets
            Assert.Equal(DeviceStatus.Heating, result);
        }
    }
}
