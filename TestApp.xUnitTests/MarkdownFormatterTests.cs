using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestApp.xUnitTests
{
    // Install-Package FluentAssertions


    public class MarkdownFormatterTests
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("a")]
        [InlineData("Lorem ipsum")]
        public void FormatAsBold_ValidContent_ShouldReturnsContentEncloseDoubleAsterix(string content)
        {
            // Arrange
            MarkdownFormatter markdownFormatter = new MarkdownFormatter();

            // Act
            var result = markdownFormatter.FormatAsBold(content);

            // Assert
            // Assert.Equal(expected, result);

            //Assert.StartsWith("**", result);
            //Assert.Contains(content, result);
            //Assert.EndsWith("**", result);

            // Fluent Assertions

            result.Should()
                .StartWith("**")
                .And
                .Contain(content)
                .And
                .EndWith("**");
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("a")]
        [InlineData("Lorem ipsum")]
        public void FormatAsBold_ValidContent_ShouldReturnsContentEncloseSingleAsterix(string content)
        {
            // Arrange
            MarkdownFormatter markdownFormatter = new MarkdownFormatter();

            // Act
            var result = markdownFormatter.FormatAsItalic(content);

            //Assert.StartsWith("*", result);
            //Assert.Contains(content, result);
            //Assert.EndsWith("*", result);

            result.Should()
                .StartWith("*")
                .And
                .Contain(content)
                .And
                .EndWith("*");
        }


        [Fact]
        public void FormatAsBold_EmptyContent_ShouldThrowsFormatException()
        {
            // Arrange
            MarkdownFormatter markdownFormatter = new MarkdownFormatter();

            // Act
            Action act = () => markdownFormatter.FormatAsBold(string.Empty);

            // Assert
            // Assert.Throws<FormatException>(act);

            act.Should().ThrowExactly<FormatException>();
        }
    }
}
