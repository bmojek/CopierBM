using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Zadanie2
{
    [TestClass]
    public class UnitTest1
    {
        public class ConsoleRedirectionToStringWriter : IDisposable
        {
            private StringWriter stringWriter;
            private TextWriter originalOutput;

            public ConsoleRedirectionToStringWriter()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOutput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }

        [TestMethod]
        public void MultifunctionalDevice_FaxCounter()
        {
            var fax1 = new MultifunctionalDevice();
            fax1.PowerOn();

            IDocument doc1 = new PDFDocument("test.pdf");
            fax1.Fax(doc1, "example@gmail.com");
            IDocument doc2 = new PDFDocument("test2.pdf"); ;
            fax1.Fax(doc2, "example@gmail.com");

            IDocument doc3 = new ImageDocument("aaa.jpg");
            fax1.Fax(doc3, "example@gmail.com");
            fax1.PowerOff();
            fax1.Fax(doc3, "example@gmail.com");

            Assert.AreEqual(3, fax1.FaxCounter);
        }

        [TestMethod]
        public void Copier_Scan_FormatTypeDocument()
        {
            var fax1 = new MultifunctionalDevice();
            fax1.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("test.pdf");
                fax1.Fax(doc1, "example@gmail.com");
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Fax"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("to"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("@"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}