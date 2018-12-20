using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GettingRealInvoiceToPdf
{
    public class DatabaseProcessing
    {
        private string connnectionString = "Server=EALSQL1.eal.local; Database= A_DB02_2018; User Id=A_STUDENT02; Password=A_OPENDB02";

        public List<InvoiceData> GetInvoices()
        {
            List<InvoiceData> invoices = new List<InvoiceData>();

            #region Database Stub
            /*
            invoices.Add(new InvoiceData { InvoiceNo = 2000, Email = "drakthan87@gmail.com" });
            invoices.Add(new InvoiceData { InvoiceNo = 3000, Email = "drakthan87@gmail.com" });
            invoices.Add(new InvoiceData { InvoiceNo = 4000, Email = "drakthan87@gmail.com" });
            invoices.Add(new InvoiceData { InvoiceNo = 5000, Email = "drakthan87@gmail.com" });

            return invoices;
            */
            #endregion
            
            using (SqlConnection con = new SqlConnection(connnectionString))
            {

                try
                {

                    int numRuns = 1; 

                    //Uses a for-loop in order to retrieve data connected to each Id
                    for (int i = 0; i < 4; i++)
                    {
                        InvoiceData invoiceData = new InvoiceData();
                        //Opens the connection to the database as well as the Stored Procedure with it's parameters
                        con.Open();
                        SqlCommand cmd = new SqlCommand("GetInvoice", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", numRuns));
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        //retrieves the desired information for each Id and saves it in an InvoiceData-object
                        string id = reader["Id"].ToString();
                        invoiceData.FName = reader["FNavn"].ToString();
                        invoiceData.LName = reader["LNavn"].ToString();
                        invoiceData.Street = reader["VejNavn"].ToString();
                        invoiceData.HouseNo = reader["HusNr"].ToString();
                        invoiceData.PhoneNo = reader["TelefonNr"].ToString();
                        invoiceData.Email = reader["Email"].ToString();
                        invoiceData.InvoiceNo = Convert.ToInt32(reader["FakturaNr"]);                        

                        invoices.Add(invoiceData);
                        con.Close();                    
                        numRuns++;                        
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + " " + e.Message);
                }

            }

            return invoices;            
        }
    }
}
