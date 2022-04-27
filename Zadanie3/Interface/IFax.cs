using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public interface IFax : IDevice
    {
        void Fax(in IDocument document, string email);
    }
}