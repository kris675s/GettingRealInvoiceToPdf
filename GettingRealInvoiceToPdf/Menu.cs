using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealInvoiceToPdf
{
    public class Menu
    {

        public static void Start()
        {
            int menuChoice = 0;
            do
            {
                Console.WriteLine(
                    "FaturaPdf \n" +
                    "Hvad vil du var?! \n" +
                    "1. Nuværende Faktura\n" +
                    "2. Send Emails\n" +
                    "\n" +
                    "0. Exit");

                menuChoice = Console.Read(); //Burger indput
                Console.Clear();
                               
                switch (menuChoice)
                {
                    case 1: //Current Pdf
                        List<InvoiceData> CurrentInvoices = Controller.GetCurrentInvoices();
                        CurrentInvoices.ForEach(x =>
                            Console.WriteLine("")
                                

                            );
                        break;
                    case 2: //
                        break;
                    case 0: // Exit
                        break;
                }

            } while (menuChoice != 0);
 
        }    

    }
}
