using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace dll_Utilities
{
    public class Utilities_Database
    {
        private string WORKINGPATH;
        private string CONNECTION_STRING;

		public Utilities_Database(string wORKINGPATH, string cONNECTION_STRING)
		{
			WORKINGPATH1 = wORKINGPATH;
			CONNECTION_STRING1 = cONNECTION_STRING;
		}

		private string WORKINGPATH1 { get => WORKINGPATH; set => WORKINGPATH = value; }
		private string CONNECTION_STRING1 { get => CONNECTION_STRING; set => CONNECTION_STRING = value; }

		public void ExecuteSqlScript(string sqlScriptName)
        {
            string fileContent = File.ReadAllText(WORKINGPATH1 + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            SqlConnection con = new SqlConnection(CONNECTION_STRING1);
            SqlCommand cmd = new SqlCommand("query", con);
            con.Open();

            int i = 0, nr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query;
                i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    System.Threading.Thread.Sleep(10000);
                    nr++;
                }
            }

            Console.Clear();
            Console.WriteLine($"Processo di creazione della tabella \"{sqlScriptName.Substring(0, sqlScriptName.IndexOf('.'))}\" terminato con {nr} error{(nr == 1 ? "e" : "i")}.");
            System.Threading.Thread.Sleep(3500);
            con.Close();
        }
    }
}