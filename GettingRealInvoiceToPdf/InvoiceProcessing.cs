using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace GettingRealInvoiceToPdf
{
    public class InvoiceProcessing
    {
        //datetime used to create folders for saving .pdf without the users need to create new folders themselves
        //datetime is not compatible to show month and day names
        //this could be edited in a later version for a better user overview (a switch case translation with a list of 12 months)
        private static string filePath = (@"..\\FakturaPdf\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Day + @"\");


        public void ConvertToPDF(InvoiceData invoiceData)
        {
            //create new directory filepaths
            System.IO.Directory.CreateDirectory(filePath);
            Directory.CreateDirectory(DateTime.Now.ToString("dd-MM-yyyy"));

            //create new document using PDFSharp
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            //graphic input
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            //additional items to add not from the database
            //Upper Center Page
            //gfx.DrawString("Dragonslair Logo:" get image from folder
            //Center Page
            //gfx.DrawString("Dragonslair WaterMark:" get image from folder
            //Lower Center Page
            //gfx.DrawString("tilføj dig til vores nyhedsmail." +register for newsletter = "tilmeld dig her"

            //Invoice Items
            //Upper Right Corner
            gfx.DrawString("FakturaNr:" + invoiceData.InvoiceNr, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopRight);
            //gfx.DrawString("cvr nr:" +invoiceData
            //gfx.DrawString("ny string
            //gfx.DrawString("ny string

            //Upper Left Corner
            //gfx.DrawString("Name:" +invoiceData.firstName+,+ invoiceData.lastName)
            //gfx.DrawString("Adress:"+ invoiceData.adress)
            //gfx.DrawString("City:"+ invoiceData.city)
            //gfx.DrawString("Zipcode:+ invoiceData.zipcode)
            //gfx.DrawString("Email:+ invoiceData.Email)

            //Center of Page
            //gfx.DrawString("Artikel navn:" +invoiceData.articleName
            //  to the left of each artikle run loop
            //gfx.DrawString("foreach article, 1 article per line containing, article id, article name, article price
            //gfx.DrawString("totalt antal artikler
            //gfx.DrawString("pris:"+ invoiceData.articlePrice
            //gfx.DrawString("totalt pris

            string fileName ="Faktura " + invoiceData.InvoiceNr +".pdf";

            //save file to path
            document.Save(filePath + fileName);
        }
        internal static string getPdf(int invoiceNr)
        {
            string[] getPdf;
            /*try
            {
            }
            //catch
            {
                throw new Exception();
            }*/
                getPdf = Directory.GetFiles(filePath); // mangler søge kodeord for at kunne lokalisere den rigtige faktura, løkkedes ikke med int invoicenr i første forsøg
            for (int i = 0; i < getPdf.Length; i++)
            {
                Console.WriteLine(getPdf[i]);
            }
            Console.ReadLine();
            return getPdf[0];
        }
    }
}
