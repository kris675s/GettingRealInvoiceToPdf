using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace GettingRealInvoiceToPdf
{
    public class DatabaseController
    {
        private static string connnectionString =
            "Server=EALSQL1.eal.local; Database= A_DB02_2018; User Id=A_STUDENT02; Password=A_OPENDB02";

        static void Main(string[] args)
        {
            DatabaseController prog = new GettingRealInvoiceToPdf.DatabaseController();
            prog.Run();
        }
        public object InvoiceData;

        private void Run()
        {
            using (SqlConnection con = new SqlConnection(connnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("GetInvoice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", "1"));
                    cmd.Parameters.Add(new SqlParameter("@Id", "2"));
                    cmd.Parameters.Add(new SqlParameter("@Id", "3"));
                    cmd.Parameters.Add(new SqlParameter("@Id", "4"));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString(); ;
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            string vejNavn = reader["VejNavn"].ToString();
                            string husNr = reader["HusNr"].ToString();
                            string tlfNr = reader["TelefonNr"].ToString();
                            string email = reader["Email"].ToString();
                            Console.WriteLine(id + " " + firstName + " " + lastName + " " + vejNavn + " " + husNr + " " + tlfNr + " " + email);
                        }
                    }
                
                } catch ( SqlException e)
                {
                    Console.WriteLine("UPS" + e.Message);
                }
            }
        }
    }
}
