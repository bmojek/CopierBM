using System;

namespace Zadanie2
{
    internal class Program
    {
        private static void Main()
        {
            var xerox = new MultifunctionalDevice();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Fax(doc1, "bartek@gmail.com");
        }
    }
}