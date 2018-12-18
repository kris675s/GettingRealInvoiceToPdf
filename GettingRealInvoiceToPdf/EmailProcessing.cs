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
            string pdfPath = InvoiceProcessing.getPdf(invoiceNr);
            
            SmtpClient smtp = new SmtpClient();

            smtp.Host = Properties.MailUserInfo.Default.SmtpHost;
            smtp.Port = Properties.MailUserInfo.Default.SmtpPort;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Properties.MailUserInfo.Default.Mail, Properties.MailUserInfo.Default.MailPass);
            smtp.Timeout = 20000;

            MailMessage msg = new MailMessage();
            MailAddress ma = new MailAddress(Properties.MailUserInfo.Default.Mail);
            msg.To.Add(customerEmail);
            msg.From = ma;
            msg.Attachments.Add(new Attachment(pdfPath));
            msg.Body = "vedhæftet er din faktura for dit køb du har foretaget igennem Dragonslair Webshop";
            msg.Subject = "Din ordre er på vej";
            smtp.Send(msg);
        }
    }
}