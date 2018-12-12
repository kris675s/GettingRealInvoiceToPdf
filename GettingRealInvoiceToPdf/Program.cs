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
    public class Program
    {
        static void Main(string[] args)
        {
            //create new document using PDFSharp
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            //graphic input
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            gfx.DrawString("FakturaNr:"+ "6050", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopRight);
            //
            const string filename = "Faktura.pdf";
            document.Save(filename);
            Process.Start(filename);
        }
    }
}
