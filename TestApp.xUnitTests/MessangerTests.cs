using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Fundamentals;

namespace TestApp.xUnitTests
{
    public class MessangerTests
    {
        public void Send_TextMessage_Sent()
        {
            // Arrange
            Messanger messanger = new Messanger();

            // Act
            messanger.Send<string>("a");

            // Assert
        }

        public void Send_VideoMessage_Sent()
        {
            // Arrange
            Messanger messanger = new Messanger();

            // Act
            messanger.Send<Video>(new Video());
        }

        public void Send_PictureMessage_Sent()
        {
            // Arrange
            Messanger messanger = new Messanger();

            // Act
            messanger.Send<byte[]>(new byte[1000]);
        }
    }
}
