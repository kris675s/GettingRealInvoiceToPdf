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
        //use datetime to create folders for saving files
        private static DateTime date = new DateTime();
        private static string standardFilePath = (@"C:\Program Files\" + @"InvoiceToPdf\" + date.Year + @"\" + date.Month + @"\" + date.Day);
            System.IO.FileInfo PdfInvoice = new System.IO.FileInfo(FilePath);

        public void SortedPdf()        
        {
            //user choose filepath directory manually
            if (filePath = standardFilePath)
            {
                Properties.Settings1 settings = System.IO.FileInfo(filePath);

                FilePath = Value;
                return override FilePath;
            }
            //sets default filepath if use dont
            if else
            {
            public static string FilePath { get => filePath; set { filePath = value; } }
            }
            
            // If the directory already exists, this method does nothing.
            else
            {
                PdfInvoice.Directory.Create(); 
            }
        document.Save(filename.path());
        Process.Start(filename);
        }
    }
}
