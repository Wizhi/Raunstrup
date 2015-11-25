using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Domain;

namespace Raunstrup.Core
{
    public interface IInvoicePrinter
    {
        void PrintInvoice(Draft draft);
    }

}
