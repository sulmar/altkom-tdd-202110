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
    public class FakeConnectedTcpClient : ITcpClient
    {
        public bool Connected => true;

        public void Connect(string hostname, int port)
        {
        }
    }

    public class FakeDisconnectedTcpClient : ITcpClient
    {
        public bool Connected => false;

        public void Connect(string hostname, int port)
        {
        }
    }

    public class RCarMockTests
    {
        [Fact]
        public void Push_WhenConnect_ShouldSetsEnabledState()
        {
            // Arrange

            Mock<ITcpClient> mockTcpClient = new Mock<ITcpClient>();

            mockTcpClient
                .Setup(tc => tc.Connect(It.IsAny<string>(), It.IsAny<int>()));

            mockTcpClient
                .SetupGet(tc => tc.Connected).Returns(true);

            ITcpClient tcpClient = mockTcpClient.Object;

            RCar target = new RCar(tcpClient);

            // Act
            target.Push();

            // Assert
            Assert.Equal(target.State, TargetStates.Enabled);
        }

        [Fact]
        public void Push_WhenConnect_ShouldSetsDisableState()
        {
            // Arrange
            Mock<ITcpClient> mockTcpClient = new Mock<ITcpClient>();

            mockTcpClient
             .Setup(tc => tc.Connect(It.IsAny<string>(), It.IsAny<int>()));

            mockTcpClient
                .SetupGet(tc => tc.Connected).Returns(true);

            ITcpClient tcpClient = mockTcpClient.Object;

            RCar target = new RCar(tcpClient);
            target.Push();

            // Act
            target.Push();

            // Assert
            Assert.Equal(target.State, TargetStates.Disabled);
        }

        [Fact]
        public void Push_WhenDisconnected_ShouldThrowApplicationException()
        {
            // Arrange
            Mock<ITcpClient> mockTcpClient = new Mock<ITcpClient>();

            mockTcpClient
                .Setup(tc => tc.Connect(It.IsAny<string>(), It.IsAny<int>()));

            mockTcpClient
                .SetupGet(tc => tc.Connected).Returns(false);

            ITcpClient tcpClient = mockTcpClient.Object;

            RCar target = new RCar(tcpClient);

            // Act
            Action act = () => target.Push();

            // Assert
            Assert.Throws<ApplicationException>(act);
        }
    }

    public class RCarTests
    {
        [Fact]
        public void Push_WhenConnect_ShouldSetsEnabledState()
        {
            // Arrange
            RCar target = new RCar(new FakeConnectedTcpClient());

            // Act
            target.Push();

            // Assert
            Assert.Equal(target.State, TargetStates.Enabled);
        }

        [Fact]
        public void Push_WhenConnect_ShouldSetsDisableState()
        {
            // Arrange
            RCar target = new RCar(new FakeConnectedTcpClient());
            target.Push();

            // Act
            target.Push();

            // Assert
            Assert.Equal(target.State, TargetStates.Disabled);
        }

        [Fact]
        public void Push_WhenDisconnected_ShouldThrowApplicationException()
        {
            // Arrange
            RCar target = new RCar(new FakeDisconnectedTcpClient());

            // Act
            Action act = () => target.Push();

            // Assert
            Assert.Throws<ApplicationException>(act);
        }
    }
}
