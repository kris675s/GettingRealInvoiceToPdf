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
                        userChoise = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 1: // Get and convert invoices to PDF
                        Console.Clear();
                        Console.WriteLine(
                            "Dagens faktura hentes samt konverteres til PDF, kan findes i: {0}\n" +
                            "Enter for hovedmenu", (@"..\\FakturaPdf\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day));
                        Controller.GetInvoices();
                        Console.ReadLine();
                        goto case 0;
                    case 2: //Send Invoices
                        string invoicesToRemove = GetDaliyInvoices();
                        if (invoicesToRemove != "")
                        {
                            RemoveInvoices(invoicesToRemove);
                            goto case 2;
                        }
                        else
                        {
                            Controller.SendEmails();
                            Console.WriteLine(
                                "Emails bliver sendt\n" +
                                "tryk Enter for at gå til hovedmenu");
                            Console.ReadLine();
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
                            "tryk Enter for at gå til hovedmenu", Properties.ProgramSettings.Default.SmtpHost, Properties.ProgramSettings.Default.SmtpPort, Properties.ProgramSettings.Default.Mail);
                        Console.ReadLine();
                        goto case 0;
                    case 4: //Set filePath
                        SetFilePath();
                        Console.Clear();
                        Console.WriteLine(
                            "Din fil sti er blevet opdateret til:\n" +
                            "{0}\n" +
                            "tryk Enter for at gå til hovedmenu", Properties.ProgramSettings.Default.FilePath);
                        Console.ReadLine();
                        goto case 0;

                    default:
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
                "3. Indstillger for smtp server\n" +
                "4. Fil sti\n" +
                "\n" +
                "6. Quit"
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
                "Tryk enter for at forsætte");

            string invoicesToRemove = Console.ReadLine();

            return invoicesToRemove;
        }

        private void RemoveInvoices(string invoicesToRemove)
        {
            string[] sArr = invoicesToRemove.Split(',');
            int[] invoiceNo = Array.ConvertAll<string, int>(sArr, int.Parse);
            
            foreach(int key in invoiceNo)
            {
                Controller.RemoveInvoice(key);
            }   
        }

        private void SetSmtpServerSettings()
        {
            Console.Clear();
            Console.WriteLine(
                "Din smtp server er: {0}\n" +
                "Tryk enter for at beholde samme, ellers angiv ny smtp server", Properties.ProgramSettings.Default.SmtpHost);
            string userInputHost = Console.ReadLine();
            if (userInputHost != "")
                Properties.ProgramSettings.Default.SmtpHost = userInputHost;

            Console.Clear();
            Console.WriteLine(
                "Din smtp port er: {0}\n" +
                "Tryk enter for at beholde samme, ellers angiv ny smtp port", Properties.ProgramSettings.Default.SmtpPort);
            string userInputPort = Console.ReadLine();
            if (userInputPort != "")
                Properties.ProgramSettings.Default.SmtpPort = int.Parse(userInputPort);

            Console.Clear();
            Console.WriteLine(
                "Din smtp mail adresse er: {0}\n" +
                "Tryk enter for at beholde samme, ellers angiv ny smtp mail adresse", Properties.ProgramSettings.Default.Mail);
            string userInputMail = Console.ReadLine();
            if (userInputMail != "")
                Properties.ProgramSettings.Default.Mail = userInputMail;

            Console.Clear();
            Console.WriteLine(
                "Dit smtp mail password er: ********\n" +
                "Tryk enter for at beholde samme, ellers angiv nyt password", Properties.ProgramSettings.Default.MailPass);
            string userInputMailpass = Console.ReadLine();
            if (userInputMailpass != "")
                Properties.ProgramSettings.Default.Mail = userInputMailpass;
        }
        private void SetFilePath()
        {
            Console.Clear();
            Console.WriteLine(
                "PDF'er bliver gemt i: {0}\n" +
                "Enter for at beholde nuværende sti, ellers angiv ny fil sti", Properties.ProgramSettings.Default.FilePath);
            string userInput = Console.ReadLine();
            if (userInput != "")
                Properties.ProgramSettings.Default.SmtpHost = userInput;
        }
        #endregion
    }
}
