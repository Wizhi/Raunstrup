using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Domain;

namespace Raunstrup.Core
{
    public abstract class InvoiceTextFormatter : IInvoicePrinter
    {
        protected StringBuilder BuildInvoice(Draft draft)
        {
            var sb = new StringBuilder();
            string companyName = "Robert Fultons Vej 22" + Environment.NewLine +"8200 Aarhus N";

            int temp = 20;

            if (temp < draft.OrderLines.Max(x => x.GetProduct().Name.Length))
            {
                temp = draft.OrderLines.Max(x => x.GetProduct().Name.Length);
            }
            if (temp < draft.Customer.Name.Length)
            {
                temp = draft.Customer.Name.Length;
            }
            //if (temp < draft.Customer.SteetName.Length + draft.Customer.StreetNumber.Length)
            //{
            //    temp = draft.Customer.SteetName.Length + draft.Customer.StreetNumber.Length;
            //}
            //if (temp < companyName.Length)
            //{
            //    temp = companyName.Length;
            //}
            string spacing = new string('-', temp+10);

            sb.AppendLine(spacing);
            sb.AppendLine(draft.Customer.Id.ToString());
            sb.AppendLine(draft.Customer.Name);
            sb.AppendLine(string.Format("{0} {1}", draft.Customer.SteetName, draft.Customer.StreetNumber));
            sb.AppendLine(string.Format("{0} {1}", draft.Customer.PostalCode, draft.Customer.City));
            sb.AppendLine(spacing);
            sb.AppendLine(string.Format(draft.StartDate.ToShortDateString() + new string(' ', temp-10) + draft.EndDate.ToShortDateString()));
            sb.AppendLine();
            foreach (var orderLine in draft.OrderLines)
            {
                sb.AppendLine(string.Format("{0} x{1}", orderLine.GetProduct().Name, orderLine.GetQuantity()));
                sb.AppendLine(string.Format(" dkk {0}", orderLine.GetTotal()));
            }

            var total = draft.OrderLines.Sum(x => x.GetTotal());
            sb.AppendLine();
            sb.AppendLine(string.Format("I ALT: {0}", total));
            sb.AppendLine(string.Format("MOMS  UDGØR: {0}", total * 0.20M));
            sb.AppendLine(spacing);
            sb.AppendLine("RAUNSTRUP A/S");
            sb.AppendLine(companyName);
            sb.AppendLine("CVR: 12345678");


            return sb;
        }

        public abstract void PrintInvoice(Draft draft);
    }
}
