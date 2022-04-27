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
            xerox.ScanFaxPrint(doc1, "bartek@gmail.com");
            xerox.Fax(doc1, "example@gmail.com");
        }
    }
}