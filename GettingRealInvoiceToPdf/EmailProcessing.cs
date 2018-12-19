using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace GettingRealInvoiceToPdf
{
    public static class EmailProcessing
    {
        public static void SentEmail(int invoiceNr, string customerEmail)
        {
            string pdfPath = InvoiceProcessing.getPdf(invoiceNr);
            
            SmtpClient smtp = new SmtpClient();

            smtp.Host = Properties.MailUserInfo.Default.SmtpHost;
            smtp.Port = Properties.MailUserInfo.Default.SmtpPort;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Properties.MailUserInfo.Default.Mail, Properties.MailUserInfo.Default.MailPass);
            smtp.Timeout = 20000;

            MailMessage message = new MailMessage();
            MailAddress mailAdress = new MailAddress(Properties.MailUserInfo.Default.Mail);
            message.To.Add(customerEmail);
            message.From = mailAdress;
            message.Attachments.Add(new Attachment(pdfPath));
            message.Body = "vedhæftet er din faktura, for det køb du har foretaget, igennem Dragonslair Webshop";
            message.Subject = "Din ordre er på vej";
            smtp.Send(message);
        }
    }
}