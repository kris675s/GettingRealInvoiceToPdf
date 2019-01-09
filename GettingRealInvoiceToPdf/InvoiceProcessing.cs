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
        private string filePath = (Properties.ProgramSettings.Default.FilePath + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Day + @"\");
        //folder for Image Files
        private string imageFolder = (Properties.ProgramSettings.Default.ImageFolder);
        private string logoFolder = (Properties.ProgramSettings.Default.ImageFolder + @"\" + "LogoFolder");
        private string watermarkFolder = (Properties.ProgramSettings.Default.ImageFolder + @"\" + "WatermarkFolder");
        private string miscFolder = (Properties.ProgramSettings.Default.ImageFolder + @"\" + "MiscFolder");


        public void ConvertToPDF(InvoiceData invoiceData)
        {
            //create new directory filepaths to hold the pdf
            Directory.CreateDirectory(filePath);
            Directory.CreateDirectory(DateTime.Now.ToString("dd-MM-yyyy"));
            Directory.CreateDirectory(imageFolder);
            Directory.CreateDirectory(miscFolder);
            //error msg if folders are empty
            if (imageFolder.Length == 0)
            {
                Console.WriteLine("imagefolder for watermark and/or logo is empty. please add images to the directory for the pdf to be created correctly");
            }
            Directory.CreateDirectory(logoFolder);
            if (logoFolder.Length == 0)
            {
                Console.WriteLine("logoFolder is empty. please add a image to the directory for the pdf to be created correctly");
            }
            Directory.CreateDirectory(watermarkFolder);
            if (watermarkFolder.Length == 0)
            {
                Console.WriteLine("watermarkFolder is empty. please add a image to the directory for the pdf to be created correctly");
            }
            //create new document using PDFSharp
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            #region Graphic input
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            XFont normalTekstFont = new XFont("Verdena", 12, XFontStyle.BoldItalic);

            //additional items to add not from the database
            //Upper Center Page
            //Logo
            //gfx.DrawImage.logoFolder("Logo.png");
            /*
            void DrawImage(XGraphics gfx, int number)
            {
            BeginBox(gfx, number, "DrawImage (original)");
            XImage image = XImage.FromFile(jpegSamplePath);
            // Left position in point
            double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
                gfx.DrawImage(image, x, 0);
            EndBox(gfx);
            }
            */

            //Center Page
            //Watermark
         

            //Lower Center Page
            //gfx.DrawString("tilføj dig til vores nyhedsmail." +register for newsletter = "tilmeld dig her"
            //add image 
            #endregion
            //Invoice Items
            #region Upper Right Corner
            gfx.DrawString("FakturaNr:" + invoiceData.InvoiceNo, titleFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopRight);
            gfx.DrawString("cvr nr:" + "21547182", normalTekstFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopRight);
            //gfx.DrawString("ny string
            //gfx.DrawString("ny string
            #endregion

            #region Upper Left Corner
            gfx.DrawString("Name:" + invoiceData.FName +" "+ invoiceData.LName, normalTekstFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Adress:" + invoiceData.Street + " " + invoiceData.HouseNo, normalTekstFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
            //gfx.DrawString("City:"+ invoiceData.city)
            //gfx.DrawString("Zipcode:+ invoiceData.zipcode)
            gfx.DrawString("Email:"+ invoiceData.Email, normalTekstFont, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
            #endregion

            #region Center of Page
            //gfx.DrawString("Artikel navn:" +invoiceData.articleName
            //  to the left of each artikle run loop
            //gfx.DrawString("foreach article, 1 article per line containing, article id, article name, article price
            //gfx.DrawString("totalt antal artikler
            //gfx.DrawString("pris:"+ invoiceData.articlePrice
            //gfx.DrawString("totalt pris
            #endregion

            string fileName ="Faktura " + invoiceData.InvoiceNo +".pdf";

            //save file to path
            document.Save(filePath + fileName);
        }
        public string getPdf(int invoiceNo)
        {
            string[] getPdf;
            string invoiceString = Convert.ToString(invoiceNo);
            getPdf = Directory.GetFiles(filePath, "*" + invoiceString + "*");
            return getPdf[0];
        }
    }
}