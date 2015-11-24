using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Model;

namespace Raunstrup.Core
{
    public abstract class InvoiceTextFormatter : IInvoicePrinter
    {
        protected StringBuilder BuildInvoice(Draft draft)
        {
            var sb = new StringBuilder();

            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine(draft.Customer.Id.ToString());
            sb.AppendLine(draft.Customer.Name);
            sb.AppendLine(string.Format("{0} {1}", draft.Customer.SteetName, draft.Customer.StreetNumer));
            sb.AppendLine(string.Format("{0} {1}", draft.Customer.PostalCode, draft.Customer.City));
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine(string.Format(draft.StartDate.ToShortDateString() + new string(' ', 30) + draft.EndDate.ToShortDateString()));
            sb.AppendLine();
            foreach (var orderLine in draft.OrderLines)
            {
                sb.AppendLine(string.Format("{0} x{1}", orderLine.GetProduct().Name, orderLine.GetQuantity()));
                sb.AppendLine(string.Format(" dkk {0}", orderLine.GetTotal()));
            }
            double total = draft.OrderLines.Sum(x => x.GetTotal());
            sb.AppendLine();
            sb.AppendLine(string.Format("I ALT: {0}", total));
            sb.AppendLine(string.Format("MOMS  UDGØR: {0}", total * 0.80));
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("Company name");
            sb.AppendLine("Company adress, company city");
            sb.AppendLine("CVR: company CVR");


            return sb;
        }

        public abstract void PrintInvoice(Draft draft);
    }
}
