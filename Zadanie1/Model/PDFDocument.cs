﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class PDFDocument : AbstractDocument
    {
        public PDFDocument(string filename) : base(filename)
        {
        }

        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.PDF;
    }
}