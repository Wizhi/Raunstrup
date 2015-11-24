﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Model;

namespace Raunstrup.Core
{
    public class InvoiceFilePrinter : InvoiceTextFormatter
    {
        public override void PrintInvoice(Draft draft)
        {
            System.IO.File.WriteAllText(@"Tilbud_" + draft.Id + ".txt", BuildInvoice(draft).ToString());
        }


    }
}