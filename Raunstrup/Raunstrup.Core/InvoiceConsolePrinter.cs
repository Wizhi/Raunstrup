using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Domain;

namespace Raunstrup.Core
{
    public class InvoiceConsolePrinter : InvoiceTextFormatter
    {
        public override void PrintInvoice(Draft draft)
        {
            Console.WriteLine(BuildInvoice(draft));
        }

        
    }
}
