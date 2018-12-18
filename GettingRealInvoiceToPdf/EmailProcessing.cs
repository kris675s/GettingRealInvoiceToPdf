using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace GettingRealInvoiceToPdf
{
    public class EmailProcessing
    { 
           // stack overflow attaching a dynamically pdf to a email c# asp.net
        <system.net>
    <mailSettings>
      <smtp>
        <network host = "host_name" port="25" userName="user name" password="password" defaultCredentials="false" />
      </smtp>
    </mailSettings>


       /*
        SmtpClient smtpClient = new SmtpClient(WebMail.SmtpServer);
        MailMessage email1 = new MailMessage();

        email1.IsBodyHtml = true;
            email1.From = new MailAddress("from@email.com");
        email1.To.Add(new MailAddress(sendemail));
            //email1.CC.Add(new MailAddress("carboncopy@foo.bar.com"));
            email1.Body = BodyTemplate;
            email1.Subject = "Please reset your password";

            var stream = new System.IO.MemoryStream(pdfBytes);
        email1.Attachments.Add(new Attachment(stream, "invoice.pdf"));
            smtpClient.Send(email1);

        return message("all mails have been sent and the list is empty")
     */
       //andet eksempel
       /*
            private void SendIt()
      {
          var fromAddress = "";
          var toAddress = "";
          //Password of your gmail address
          const string fromPassword = "";
          // smtp settings
          var smtp = new System.Net.Mail.SmtpClient();
          {
              smtp.Host = "";
              smtp.Port = 25;
              smtp.EnableSsl = false;
              smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
              smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
              smtp.Timeout = 20000;
          }
          MailMessage msg = new MailMessage();
          MailAddress ma = new MailAddress(fromAddress);
          msg.To.Add(toAddress);
          msg.From = ma;
          msg.Attachments.Add(new Attachment(@"C:\temp\myreport.log"));
          msg.Body = "Your body message";
          msg.Subject = "Your subject line";
          smtp.Send(msg);
      }*/
      }
  }
