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



        public void Run()
        {
            //Controller controller = new Controller();
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
                        invoiceData.VejNavn = reader["VejNavn"].ToString();
                        invoiceData.HusNr = reader["HusNr"].ToString();
                        invoiceData.TelefonNr = reader["TelefonNr"].ToString();
                        invoiceData.Email = reader["Email"].ToString();
                        invoiceData.InvoiceNr = Convert.ToInt32(reader["FakturaNr"]);

                        //controller.NewInvoice(invoiceData);

                        // Console.WriteLine("{0} Navn: {1} {2} Adresse: {3} {4} Tlf nr: {5} Email: {6}",id,firstName,lastName,vejNavn,husNr,tlfNr,email);
                        numRuns++;
                        con.Close();
                    }

                }
                

                /* if (reader.HasRows)
                 {
                     while (reader.Read())
                     {
                         string id = reader["Id"].ToString();
                          string firstName = reader["FNavn"].ToString();
                          string lastName = reader["LNavn"].ToString();
                         string vejNavn = reader["VejNavn"].ToString();
                          string husNr = reader["HusNr"].ToString();
                          string tlfNr = reader["TelefonNr"].ToString();
                          string email = reader["Email"].ToString();

                         Console.WriteLine(id +" " + "Navn: " + firstName + " " + lastName + " " + "Addresse: " + vejNavn + " " + husNr + " " + "Telefon Nr: " + tlfNr + " " + "Email: " + email);
                         //Console.WriteLine(id + " " + firstName + " " + lastName + " " + vejNavn + " " + husNr + " " + tlfNr + " " + email);
                     }

                 }*/


                catch (SqlException e)
                {
                    Console.WriteLine("UPS" + " " + e.Message);
                }
            }
        }
    }
}
