using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    internal class Faxx : IFax
    {
        private IDevice.State device1 = IDevice.State.off;
        public int Counter { get; set; }

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

        public void Fax(in IDocument document, string email)
        {
            if (device1 is IDevice.State.on)
            {
                Console.WriteLine($"{ DateTime.Now} Fax: {document.GetFileName()} to: {email}");
            }
        }
    }
}