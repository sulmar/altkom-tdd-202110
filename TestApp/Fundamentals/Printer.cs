using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public class Printer
    {
        private string last;

        public void Print(string content)
        {
            Console.WriteLine(content);

            last = content;
        }

        public string GetLast()
        {
            return last;
        }
    }
}
