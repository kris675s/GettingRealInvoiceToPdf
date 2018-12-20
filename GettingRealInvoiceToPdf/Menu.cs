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

            switch (userChoise)
            {
                case 0: // MainMenu
                    ShowMainMenu();
                    userChoise = Console.Read();
                    break;
                case 1: // Get and convert invoices to PDF

                case 2: //Sent Invoices
                    string invoicesToRemove = GetDaliyInvoices();
                    if(invoicesToRemove != null)
                    {
                    RemoveInvoices(invoicesToRemove);
                        goto case 2;
                    }
                    else
                    {
                        Console.WriteLine(
                            "Emails bliver sent\n" +
                            "Enter for hovedmenu");
                        Console.Read();
                        break;
                    }
            } 
        }

        #region Menu Methods

        void ShowMainMenu()
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
                "Esc Quit"
                );
        }

        string GetDaliyInvoices()
        {
            Dictionary<int, InvoiceData> invoiceDic = Controller.GetInvoices();

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

        void RemoveInvoices(string invoicesToRemove)
        {
            string[] sArr = invoicesToRemove.Split(',');
            int[] invoiceNums = Array.ConvertAll<string, int>(sArr, int.Parse);
            
            foreach(int key in invoiceNums)
            {
                Controller.RemoveInvoice(key);
            }
        }

        #endregion


    }
}
