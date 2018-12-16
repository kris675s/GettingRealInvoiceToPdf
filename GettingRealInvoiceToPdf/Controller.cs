using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealInvoiceToPdf
{
    public abstract class Controller
    {

        public abstract object NewInvoice(DatabaseController InvoiceData);
        public abstract object InvoiceData(string Email, int InvoiceNr);
        private string Email { get; set; }
        private string InvoiceNr { get; set; }
        
        
    }
}
