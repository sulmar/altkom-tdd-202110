using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestApp.xUnitTests
{
    public class MarkdownFormatterTests
    {
        [Theory]
        [InlineData("abc", "**abc**")]
        [InlineData("a", "**a**")]
        [InlineData("Lorem ipsum", "**Lorem ipsum**")]
        public void FormatAsBold_ValidContent_ShouldReturnsContentEncloseDoubleAsterix(string content, string expected)
        {
            // Arrange
            MarkdownFormatter markdownFormatter = new MarkdownFormatter();

            // Act
            var result = markdownFormatter.FormatAsBold(content);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FormatAsBold_EmptyContent_ShouldThrowsFormatException()
        {
            // Arrange
            MarkdownFormatter markdownFormatter = new MarkdownFormatter();

            // Act
            Action act = () => markdownFormatter.FormatAsBold(string.Empty);

            // Assert
            Assert.Throws<FormatException>(act);
        }
    }
}
