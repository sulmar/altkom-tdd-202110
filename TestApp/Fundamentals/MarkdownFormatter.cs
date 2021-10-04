using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    // Markdown syntax
    // https://www.markdownguide.org/basic-syntax/
        
    public class MarkdownFormatter
    {
        public string FormatAsBold(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new FormatException();

            return $"**{content}**";
        }

        public string FormatAsItalic(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new FormatException();

            return $"**{content}**";
        }


    }
}
