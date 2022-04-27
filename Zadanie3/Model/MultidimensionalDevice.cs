using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MultidimensionalDevice : IPrinter, IScanner, IFax
    {
        private IDevice.State device1 = IDevice.State.off;
        private IDocument document1;
        public int Counter { get; private set; } = 0;
        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public int FaxCounter { get; private set; } = 0;
        private readonly Printer p = new();
        private readonly Scanner s = new();
        private readonly Faxx f = new();

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
            p.PowerOn();
            p.Print(document);
            p.PowerOff();
            if (device1 is IDevice.State.on) PrintCounter++;
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            s.PowerOn();
            s.Scan(out document, formatType);
            s.PowerOff();
            if (device1 is IDevice.State.on) ScanCounter++;
        }

        public void ScanAndPrint()
        {
            if (device1 is IDevice.State.on)
            {
                Scan(out document1, IDocument.FormatType.JPG);
                Print(document1);
            }
        }

        public void Fax(in IDocument document, string email)
        {
            f.PowerOn();
            f.Fax(document, email);
            f.PowerOff();
            if (device1 is IDevice.State.on) FaxCounter++;
        }
    }
}