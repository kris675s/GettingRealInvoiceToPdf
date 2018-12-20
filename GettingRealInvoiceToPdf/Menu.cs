using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GettingRealInvoiceToPdf
{
    public class Menu
    {
        private Controller controller;

        public void StartMenu()
        {
            controller = new Controller();

            int userChoise = 0;
            do
            {
                // MainMenu
                ShowMainMenu();
                userChoise = Convert.ToInt32(Console.ReadLine());


                switch (userChoise)
                {                  
                    case 1: // Get and convert invoices to PDF
                        Console.Clear();
                        Console.WriteLine(
                            "Dagens faktura hentes samt konverteres til PDF, kan findes i: {0}\n" +
                            "\n" +
                            "Enter for hovedmenu", Path.GetFullPath(@"..\\FakturaPdf\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day));
                        controller.GetInvoices();
                        Console.ReadLine();
                        break;

                    case 2: //Send Invoices
                        int[] invoicesToRemove = null;
                        do
                        {
                            invoicesToRemove = GetDaliyInvoices();

                            if (invoicesToRemove.Length != 0)
                            {
                                RemoveInvoices(invoicesToRemove);
                            }

                        } while (invoicesToRemove.Length != 0);
                        
                        controller.SendEmails();
                        Console.WriteLine(
                            "Emails bliver sendt\n" +
                            "tryk Enter for at gå til hovedmenu");
                        Console.ReadLine();
                        break;                        

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
                        break;

                    case 4: //Set filePath
                        SetFilePath();
                        Console.Clear();
                        Console.WriteLine(
                            "Din fil sti er blevet opdateret til:\n" +
                            "{0}\n" +
                            "tryk Enter for at gå til hovedmenu", Properties.ProgramSettings.Default.FilePath);
                        Console.ReadLine();
                        break;

                    default:
                        break;
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

        private int[] GetDaliyInvoices()
        {
            List<InvoiceData> invoices = controller.Invoices;

            Console.Clear();
            Console.WriteLine("Dagens Faktura\n");

            for (int i = 0; i < invoices.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, invoices[i].InvoiceNo);
            }

            Console.WriteLine(
                "\n" +
                "Vælg faktura at fjerne eks. 3, 5, 7. Afslut med Enter\n" +
                "Tryk enter for at forsætte");

            string invoicesToRemove = Console.ReadLine();
            int[] invoiceIndex = new int[0];

            if (invoicesToRemove != "")
            {

                string[] sArr = invoicesToRemove.Split(',');
                invoiceIndex = Array.ConvertAll<string, int>(sArr, int.Parse);

                for (int i = 0; i < invoiceIndex.Length; i++)
                {
                    invoiceIndex[i] -= 1;
                }

            }

            return invoiceIndex;
        }

        private void RemoveInvoices(int[] invoicesToRemove)
        {
            foreach (int index in invoicesToRemove)
            {
                controller.RemoveInvoice(index);

                for (int i = 0; i < invoicesToRemove.Length; i++)
                {
                    invoicesToRemove[i] -= 1;
                }
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
                "Enter for at beholde nuværende sti, ellers angiv ny fil sti", Path.GetFullPath(Properties.ProgramSettings.Default.FilePath));
            string userInput = Console.ReadLine();
            if (userInput != "")
                Properties.ProgramSettings.Default.FilePath = userInput;
        }
        #endregion
    }
}
