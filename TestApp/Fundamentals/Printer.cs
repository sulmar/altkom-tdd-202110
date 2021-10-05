using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    // Klasy generyczne (uogólnione)
    public class TextPrinter : Printer<string>
    {

    }

    public class DatePrinter : Printer<DateTime>
    {

    }

    public class NumberPrinter : Printer<int>
    {

    }

    public class MoneyPrinter : Printer<decimal>
    {

    }

    // Szablon klasy - Klasa generyczna
    public class Printer<TContent>
    {
        private TContent last;

        public void Print(TContent content)
        {
            Console.WriteLine(content);

            last = content;
        }

        public TContent GetLast()
        {
            return last;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public byte[] Movie { get; set; }
    }

    public class Messanger
    {
        // Szablon metody - Metoda generyczna
        public void Send<TContent>(TContent content)
        {
            Console.WriteLine(content);
        }
    }
    
}
