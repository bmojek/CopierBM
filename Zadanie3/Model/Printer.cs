﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        public IDevice.State device1 = IDevice.State.off;
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

        public void Print(in IDocument document)
        {
            if (device1 is IDevice.State.on)
            {
                Console.WriteLine($"{ DateTime.Now} Print: {document.GetFileName()}");
            }
        }
    }
}