using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class ImageDocument : AbstractDocument
    {
        public ImageDocument(string filename) : base(filename)
        {
        }

        public override IDocument.FormatType GetFormatType() => IDocument.FormatType.JPG;
    }
}