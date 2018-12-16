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

        public void SortedPdf(Id, Pdf)
        
        {
            //user choose filepath directory manually
            if (filePath = default)
            {
                Properties.Settings1 settings = System.IO.FileInfo(filePath);
            }
            //sets default filepath if use dont
            if else
            {
            public static string FilePath { get => filePath; set { filePath = value; } }
            private static string filePath = (@"C:\Program Files\" + @"InvoiceToPdf\" + date.Year + @"\" + date.Month + @"\" + date.Day);
            System.IO.FileInfo PdfInvoice = new System.IO.FileInfo(FilePath);
            }
            else
            {
                PdfInvoice.Directory.Create(); // If the directory already exists, this method does nothing.
            }
        document.Save(filename.path());
        Process.Start(filename);
        }
    }
}
