using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.MSUnitTests
{
    [TestClass]
    public class LoggerTests
    {

        [TestMethod]
        public void Log_ValidMessage_SetLastMessage()
        {
            // Arrange
            Logger logger = new Logger();

            // Act
            logger.Log("a");

            // Assert
            Assert.AreEqual("a", logger.LastMessage);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Log_NullMessage_ThrowsArgumentNullException()
        {
            // Arrange
            Logger logger = new Logger();

            // Act
            logger.Log(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Log_EmptyMessage_ThrowsArgumentNullException()
        {
            // Arrange
            Logger logger = new Logger();

            // Act
            logger.Log(string.Empty);

        }

        private string WhiteSpace => " ";

        //private string Whitespace 
        //{
        //    get
        //    {
        //        return " ";
        //    }
        //}

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Log_WhiteSpaceMessage_ThrowsArgumentNullException()
        {
            // Arrange
            Logger logger = new Logger();

            // Act
            logger.Log(WhiteSpace);
        }


        // Testowanie zdarzeń (events)
        [TestMethod]
        public void Log_ValidMessage_RaiseMessageLoggedEvent()
        {
            // Arrange
            Logger logger = new Logger();
            DateTime id = default(DateTime);
            logger.MessageLogged += (sender, args) => { id = args; };

            // Act
            logger.Log("a");

            // Assert
            Assert.AreNotEqual(default(DateTime), id);


        }

    }
}
