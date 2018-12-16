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
        public void ConvertToPDF(object id)
        {
            //create new document using PDFSharp
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            //graphic input
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            //Upper Right Corner
            gfx.DrawString("FakturaNr:" + "6050", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopRight.LineAlignment());
            //gfx.DrawString("cvr nr
            //gfx.DrawString("ny string
            //gfx.DrawString("ny string

            //Upper Left Corner
            //gfx.DrawString("firstName lastName")
            //gfx.DrawString("RoadName)
            //gfx.DrawString("City)
            //gfx.DrawString("Zipcode)
            //gfx.DrawString("Email)

            //upper Center of Page
            //gfx.DrawString("Dragonslair Logo

            //Center of Page
            //gfx.DrawString("articles"
            //gfx.DrawString("foreach article, 1 article per line containing, article id, article name, article price
            //gfx.DrawString("totalt antal artikler
            //gfx.DrawString("watermark

            //lower center page
            //gfx.DrawString("register for newsletter
            //gfx.DrawString("


            const string fileName = "Invoice" + invoiceNr +".pdf";

            //line below is to see the document, delete when done
            document.Save(fileName);
            Process.Start(fileName);
        }

    }
}
