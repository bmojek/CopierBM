using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Copier : IPrinter, IScanner
    {
        private IDevice.State device1 = IDevice.State.off;
        private IDocument document1;
        public int Counter { get; private set; } = 0;
        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;

        public IDevice.State GetState()
        {
            if (device1 is IDevice.State.on)
            {
                return IDevice.State.on;
            }
            return IDevice.State.off;
        }

        public void PowerOff()
        {
            device1 = IDevice.State.off;
        }

        public void PowerOn()
        {
            if (device1 == IDevice.State.off) Counter++;
            device1 = IDevice.State.on;
        }

        public void Print(in IDocument document)
        {
            if (device1 is IDevice.State.on)
            {
                Console.WriteLine($"{ DateTime.Now} Print: {document.GetFileName()}");
                PrintCounter++;
                document1 = document;
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (device1 is IDevice.State.on) ScanCounter++;

            if (formatType is IDocument.FormatType.TXT)
                document = new TextDocument($"TextScan{Counter}.txt");
            else if (formatType is IDocument.FormatType.JPG)
                document = new TextDocument($"ImageScan{Counter}.jpg");
            else
                document = new TextDocument($"PDFScan{Counter}.pdf");

            if (device1 is IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now} Scan: {document.GetFileName()}");
            }
        }

        public void ScanAndPrint()
        {
            if (device1 is IDevice.State.on)
            {
                Scan(out document1, IDocument.FormatType.JPG);
                Print(document1);
            }
        }
    }
}