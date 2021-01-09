using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace dll_Utilities
{
    public class Utilities_Database
    {
        private string WORKINGPATH;
        private string CONNECTION_STRING;

        private string WORKINGPATH1 { get => WORKINGPATH; set => WORKINGPATH = value; }

        private string CONNECTION_STRING1 { get => CONNECTION_STRING; set => CONNECTION_STRING = value; }

        public Utilities_Database(string workingpath, string connection_string)
		{
			WORKINGPATH1 = workingpath;
			CONNECTION_STRING1 = connection_string;
		}

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
                    nr++;
                }
            }

            Console.Clear();
            Console.WriteLine($"Processo di creazione della tabella \"{sqlScriptName.Substring(0, sqlScriptName.IndexOf('.'))}\" terminato con {nr} error{(nr == 1 ? "e" : "i")}.");
            System.Threading.Thread.Sleep(3500);
            con.Close();
        }


        public void getTableName(ref List<string> tableName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("query", con);
            con.Open();
            int nr = 0;

            cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tableName.Add(reader[0].ToString());
                }
            }
            catch (SqlException err)
            {
                Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                Console.ReadKey();
                nr++;
            }
        }

        public DataTable getTableElement(string tbName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM {tbName}";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    // create data adapter
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    // this will query your database and return the result to your datatable
                    da.Fill(dt);
                    connection.Close();
                    da.Dispose();
                }
            }
            return dt;
        }

        public List<string> getTableName()
        {
            List<string> tbName = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                StringBuilder sb = new StringBuilder();
                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader.GetString(0));
                            tbName.Add($"{reader.GetString(0)}");
                        }
                    }
                }
            }
            return tbName;
        }
    }
}