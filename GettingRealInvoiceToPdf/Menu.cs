using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealInvoiceToPdf
{
    public class Menu
    {
        public Controller Controller { get; private set; }

        public void StartMenu()
        {
            Controller = new Controller();

            int userChoise = 0;
            do
            {

                switch (userChoise)
                {
                    case 0: // MainMenu
                        ShowMainMenu();
                        userChoise = Console.Read();
                        break;
                    case 1: // Get and convert invoices to PDF
                        Controller.GetInvoices();
                        Console.Clear();
                        Console.WriteLine(
                            "Dagens faktura hentes samt conventeres til PDF, kan findes {0}\n" +
                            "Enter for hovedmenu", (@"..\\FakturaPdf\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day));
                        Console.Read();
                        goto case 0;
                    case 2: //Sent Invoices
                        string invoicesToRemove = GetDaliyInvoices();
                        if (invoicesToRemove != null)
                        {
                            RemoveInvoices(invoicesToRemove);
                            goto case 2;
                        }
                        else
                        {
                            Controller.SendEmails();
                            Console.WriteLine(
                                "Emails bliver sent\n" +
                                "Enter for hovedmenu");
                            Console.Read();
                            goto case 0;
                        }
                    case 3: // Settings for smtp server
                        SetSmtpServerSettings();
                        Console.Clear();
                        Console.WriteLine(
                            "Dine Smtp server indstillinger er blevet opdateret til:\n" +
                            "Server: {0}\n" +
                            "Port: {1}\n" +
                            "Login: {2}\n" +
                            "Enter for hovedmenu", Properties.ProgramSettings.Default.SmtpHost, Properties.ProgramSettings.Default.SmtpPort, Properties.ProgramSettings.Default.Mail);
                        Console.Read();
                        goto case 0;
                    case 4:
                        SetFilePath();
                        Console.Clear();
                        Console.WriteLine(
                            "Din fil sti er blevet opdateret til:\n" +
                            "{0}\n" +
                            "Enter for hovedmenu",Properties.ProgramSettings.Default.FilePath);
                        Console.Read();
                        goto case 0;
                }

            } while (userChoise != 6);
        }

        #region Menu Methods

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "\n" +
                "\n" +
                "InvoicePDF\n" +
                "1. Hent dagens faktura\n" +
                "2. Send dagens faktura\n" +
                "3. Indstillinger\n" +
                "\n" +
                "5. Quit"
                );
        }

        private string GetDaliyInvoices()
        {
            Dictionary<int, InvoiceData> invoiceDic = Controller.GetInvoiceDict();

            Console.Clear();
            Console.WriteLine("Dagens Faktura\n");

            foreach(KeyValuePair<int, InvoiceData> pair in invoiceDic)
            {
                Console.WriteLine(pair.Key.ToString(), pair.Value.InvoiceNo);
            }

            Console.WriteLine(
                "\n" +
                "Vælg faktura at fjerne eks. 3, 5, 7. Afslut med Enter\n" +
                "Enter for at forsætte");

            string invoicesToRemove = Console.ReadLine();

            return invoicesToRemove;
        }

        private void RemoveInvoices(string invoicesToRemove)
        {
            string[] sArr = invoicesToRemove.Split(',');
            int[] invoiceNums = Array.ConvertAll<string, int>(sArr, int.Parse);
            
            foreach(int key in invoiceNums)
            {
                Controller.RemoveInvoice(key);
            }
        }

        private void SetSmtpServerSettings()
        {
            Console.Clear();
            Console.WriteLine(
                "Din smtp server er {0}\n" +
                "Enter for at beholde samme, ellers angiv ny smtp server", Properties.ProgramSettings.Default.SmtpHost);
            string userInputHost = Console.ReadLine();
            if (userInputHost != null)
                Properties.ProgramSettings.Default.SmtpHost = userInputHost;

            Console.Clear();
            Console.WriteLine(
                "Din smtp port er {0}\n" +
                "Enter for at beholde samme, ellers angiv ny smtp port", Properties.ProgramSettings.Default.SmtpPort);
            int userInputPort = int.Parse(Console.ReadLine());
            if (userInputPort != 0)
                Properties.ProgramSettings.Default.SmtpPort = userInputPort;

            Console.Clear();
            Console.WriteLine(
                "Din smtp mail adresse er {0}\n" +
                "Enter for at beholde samme, ellers angiv ny smtp port", Properties.ProgramSettings.Default.Mail);
            string userInputMail = Console.ReadLine();
            if (userInputMail != null)
                Properties.ProgramSettings.Default.Mail = userInputMail;

            Console.Clear();
            Console.WriteLine(
                "Din smtp mail adresse er {0}\n" +
                "Enter for at beholde samme, ellers angiv ny smtp port", Properties.ProgramSettings.Default.MailPass);
            string userInputMailpass = Console.ReadLine();
            if (userInputMailpass != null)
                Properties.ProgramSettings.Default.Mail = userInputMailpass;
        }
        private void SetFilePath()
        {
            Console.Clear();
            Console.WriteLine(
                "PDF'er bliver gemt i {0}\n" +
                "Enter for at beholde samme, ellers angiv ny fil sti", Properties.ProgramSettings.Default.FilePath);
            string userInput = Console.ReadLine();
            if (userInput != null)
                Properties.ProgramSettings.Default.SmtpHost = userInput;
        }

        #endregion


    }
}
