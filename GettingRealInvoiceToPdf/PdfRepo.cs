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
using System.Collections;

namespace GettingRealInvoiceToPdf
{
    public class PdfRepo
    {
        private static DateTime date = new DateTime();

        public void SortedPdf(Id.Pdf)
        {
            public static string FilePath { get; set; }
            private static string filePath = (@"C:\Program Files\" + @"InvoiceToPdf\" + date.Year + @"\" + date.Month + @"\" + date.Day);;
        //if user sets path then dont run filepath
        System.IO.FileInfo PdfInvoice = new System.IO.FileInfo(FilePath);
            //
            PdfInvoice.Directory.Create(); // If the directory already exists, this method does nothing.
        }
        document.Save(filename.path());
        Process.Start(filename);
    }
}
