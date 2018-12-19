using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealInvoiceToPdf
{
    public class Controller
    {
        readonly List<InvoiceData> daliyInvoices = new List<InvoiceData>();

        //Tilføjerfaktura til en liste over alle daglige faktura, conventere til PDF
        public void NewInvoice(InvoiceData invoiceData)
        {
            AddInvoice(invoiceData);

            InvoiceProcessing.ConvertToPDF(invoiceData);
        }

        //Køre igennem alle faktura og får dem send, holder styr på mails som er afsend eller ikke afsted. Sletter afsendte mails 
        public void SentDaliyEmails()
        {
            List<InvoiceData> daliySentInvoices = new List<InvoiceData>();

            //menu.invoicesNotToSent(daliyInvoices);

            //Metode for at tjekke for fejl i afsendelse, og hvis fejl, tilføjer ikke til daliySentInvoices

            daliyInvoices.ForEach(x => {
                EmailProcessing.SendEmail(x.InvoiceNr, x.Email);
                daliySentInvoices.Add(x);
            });

            daliySentInvoices.ForEach(x => RemoveInvoice(x));

            //Menu X Mails not sent or all sent without problems
        }

        private void AddInvoice(InvoiceData invoiceData)
        {
            daliyInvoices.Add(invoiceData);
        }
        private void RemoveInvoice(InvoiceData invoiceData)
        {
            daliyInvoices.Remove(invoiceData);
        }
        
    }
}
