using System;

namespace Zadanie3
{
    internal class Program
    {
        private static void Main()
        {
            var xerox = new MultidimensionalDevice();
            xerox.PowerOn();
            IDocument document = new PDFDocument("aa.pdf");
            xerox.Print(in document);
            xerox.Scan(out document, IDocument.FormatType.PDF);
            xerox.Scan(out document, IDocument.FormatType.PDF);
        }
    }
}