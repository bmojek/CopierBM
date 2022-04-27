namespace Zadanie3
{
    public class Copier : IPrinter, IScanner
    {
        public IDevice.State device1 = IDevice.State.off;
        public IDocument document1;
        public int Counter { get; set; } = 0;
        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;
        private readonly Printer p = new();
        private readonly Scanner s = new();

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
    }
}