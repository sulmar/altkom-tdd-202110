using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Mocking;
using Xunit;

namespace TestApp.xUnitTests
{
    public class ConnectedTcpClient : ITcpClient
    {
        public bool Connected => true;

        public void Connect(string hostname, int port)
        {            
        }
    }

    public class DisconnectedTcpClient : ITcpClient
    {
        public bool Connected => false;

        public void Connect(string hostname, int port)
        {
        }
    }

    public class RCarTests
    {
        [Fact]
        public void Push_WhenConnect_ShouldSetsEnabledState()
        {
            // Arrange
            RCar target = new RCar(new ConnectedTcpClient());

            // Act
            target.Push();

            // Assert
            Assert.Equal(target.State, TargetStates.Enabled);
        }

        [Fact]
        public void Push_WhenConnect_ShouldSetsDisableState()
        {
            // Arrange
            RCar target = new RCar(new ConnectedTcpClient());
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
            RCar target = new RCar(new DisconnectedTcpClient());

            // Act
            Action act = () => target.Push();

            // Assert
            Assert.Throws<ApplicationException>(act);
        }
    }
}
