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
        private string connnectionString =
            "Server=EALSQL1.eal.local; Database= A_DB02_2018; User Id=A_STUDENT02; Password=A_OPENDB02";



        public void GetInvoices()
        {
            Controller controller = new Controller();
            using (SqlConnection con = new SqlConnection(connnectionString))
            {

                try
                {

                    int numRuns = 1; 

                    for (int i = 0; i < 4; i++)
                    {
                        InvoiceData invoiceData = new InvoiceData();

                        con.Open();
                        SqlCommand cmd = new SqlCommand("GetInvoice", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", numRuns));
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();

                        string id = reader["Id"].ToString();
                        invoiceData.FName = reader["FNavn"].ToString();
                        invoiceData.LName = reader["LNavn"].ToString();
                        invoiceData.Street = reader["VejNavn"].ToString();
                        invoiceData.HouseNo = reader["HusNr"].ToString();
                        invoiceData.PhoneNo = reader["TelefonNr"].ToString();
                        invoiceData.Email = reader["Email"].ToString();
                        invoiceData.InvoiceNr = Convert.ToInt32(reader["FakturaNr"]);

                        controller.NewInvoice(invoiceData);
                        numRuns++;
                        con.Close();
                        
                    }

                    
                }


                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + " " + e.Message);
                }
            }
        }
    }
}
