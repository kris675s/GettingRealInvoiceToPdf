using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealInvoiceToPdf
{
    public class Controller
    {        
        public List<InvoiceData> Invoices { get; private set; }
        // Calls DatabaseProcessing for all new invoices
        public void GetInvoices()
        {
            DatabaseProcessing databaseProcessing = new DatabaseProcessing();
            Invoices = databaseProcessing.GetInvoices();
            Invoices.ForEach(x => NewInvoice(x));
        }

        //Gets invoiceData obj from database, storage in List and calls pdf convertion
        public void NewInvoice(InvoiceData invoiceData)
        {
            InvoiceProcessing invoiceProcessing = new InvoiceProcessing();

            invoiceProcessing.ConvertToPDF(invoiceData);
        }

        //Loops our List, sends emails with the right parameters 
        public void SendEmails()
        {
            EmailProcessing emailProcessing = new EmailProcessing();

            Invoices.ForEach(x => emailProcessing.SendEmail(x.InvoiceNo, x.Email));            
        }

        public void RemoveInvoice(int index)
        {
            Invoices.RemoveAt(index);
        }        
    }
}
