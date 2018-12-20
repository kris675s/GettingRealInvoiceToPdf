using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealInvoiceToPdf
{
    public class Controller
    {
        //readonly List<InvoiceData> invoices = new List<InvoiceData>();
        readonly Dictionary<int, InvoiceData> invoices = new Dictionary<int, InvoiceData>();
        // Calls DatabaseProcessing for all new invoices
        public void GetInvoices()
        {
        }
        //Tilføjerfaktura til en liste over alle daglige faktura, conventere til PDF
        public void NewInvoice(InvoiceData invoiceData)
        {
            InvoiceProcessing invoiceProcessing = new InvoiceProcessing();

            AddInvoice(invoiceData);

            invoiceProcessing.ConvertToPDF(invoiceData);
        }

        //Køre igennem alle faktura og får dem send, holder styr på mails som er afsend eller ikke afsted. Sletter afsendte mails 
        public void SentEmails(Dictionary<InvoiceData, int> invoiceData)
        {
            List<InvoiceData> sentInvoices = new List<InvoiceData>();
            EmailProcessing emailProcessing = new EmailProcessing();

            //menu.invoicesNotToSent(daliyInvoices);

            //Metode for at tjekke for fejl i afsendelse, og hvis fejl, tilføjer ikke til daliySentInvoices

            invoiceData.ForEach(x => {
                emailProcessing.SentEmail(x.InvoiceNr, x.Email);
                sentInvoices.Add(x);
            });

            sentInvoices.ForEach(x => RemoveInvoice(x));

            //Menu X Mails not sent or all sent without problems
        }


        public void AddInvoice(InvoiceData invoiceData)
        {
            int key = invoices.Count + 1; 
            invoices.Add(key, invoiceData);
        }
        public void RemoveInvoice(int key)
        {
            invoices.Remove(key);
        }
        public Dictionary<int, InvoiceData> GetInvoices()
        {
            return invoices;
        }
        
    }
}
