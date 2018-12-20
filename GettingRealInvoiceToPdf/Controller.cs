using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealInvoiceToPdf
{
    public class Controller
    {        
        private readonly Dictionary<int, InvoiceData> invoices = new Dictionary<int, InvoiceData>();
        // Calls DatabaseProcessing for all new invoices
        public void GetInvoices()
        {
            DatabaseProcessing databaseProcessing = new DatabaseProcessing();
            databaseProcessing.GetInvoices();
        }

        //Gets invoiceData obj from database, storage in Dict and calls pdf convertion
        public void NewInvoice(InvoiceData invoiceData)
        {
            InvoiceProcessing invoiceProcessing = new InvoiceProcessing();

            AddInvoice(invoiceData);

            invoiceProcessing.ConvertToPDF(invoiceData);
        }

        //Loops our Dict, sends emails with the right parameters 
        public void SendEmails()
        {
            EmailProcessing emailProcessing = new EmailProcessing();

            foreach(KeyValuePair<int,InvoiceData>pair in invoices)
            {
                emailProcessing.SendEmail(pair.Value.InvoiceNo, pair.Value.Email);
            }
            
        }

        public void AddInvoice(InvoiceData invoiceData)
        {
            int key = (invoices.Count + 1);
            invoices.Add(key, invoiceData);
        }
        public void RemoveInvoice(int key)
        {
            invoices.Remove(key);
        }
        public Dictionary<int, InvoiceData> GetInvoiceDict()
        {
            return invoices;
        }
        
    }
}
