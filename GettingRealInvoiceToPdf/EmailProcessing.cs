using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace GettingRealInvoiceToPdf
{
    public class EmailProcessing
    {
        public void SendEmail(int invoiceNr, string customerEmail)
        {
            InvoiceProcessing invoiceProcessing = new InvoiceProcessing();
            string pdfPath = invoiceProcessing.getPdf(invoiceNr);
            
            SmtpClient smtp = new SmtpClient();

            smtp.Host = Properties.ProgramSettings.Default.SmtpHost;
            smtp.Port = Properties.ProgramSettings.Default.SmtpPort;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Properties.ProgramSettings.Default.Mail, Properties.ProgramSettings.Default.MailPass);
            smtp.Timeout = 20000;

            MailMessage message = new MailMessage();
            MailAddress mailAdress = new MailAddress(Properties.ProgramSettings.Default.Mail);
            message.To.Add(customerEmail);
            message.From = mailAdress;
            message.Attachments.Add(new Attachment(pdfPath));
            message.Body = "vedhæftet er din faktura, for det køb du har foretaget, igennem Dragonslair Webshop";
            message.Subject = "Din ordre er på vej";
            smtp.Send(message);
        }
    }
}