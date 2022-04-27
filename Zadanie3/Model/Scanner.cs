using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public IDevice.State device1 = IDevice.State.off;
        public int Counter { get; set; } = 0;

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

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
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
    }
}