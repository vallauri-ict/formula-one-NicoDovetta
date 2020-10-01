using System;
using System.IO;
using System.Data.SqlClient;

namespace formulaOne_console
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        private static void menu()
        {
            Console.Clear();
            Console.Title = "Formula one - Batch operations";
            Console.WriteLine("*** Formula one - Batch operations ***");
            Console.WriteLine("1 - Execute import countries table;");
            Console.WriteLine("2 - Execute import teams table;");
            Console.WriteLine("3 - Execute import drivers table;");
            Console.WriteLine("X - Exit.");
            Console.Write("\nYour selection: ");
        }

        static void Main(string[] args)
        {
            char c;
            do
            {
                menu();
                c = Console.ReadKey().KeyChar;
                switch (c)
                {
                    case '1':
                        ExecuteSqlScript("Countries.sql");
                        break;
                    default:
                        if (c != 'x' && c != 'X')
                        {
                            Console.WriteLine("Effettua un'altra selezione.");
                        }
                        break;
                }
            } while (c != 'x' && c != 'X');
        }

        public static void ExecuteSqlScript(string sqlScriptName)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent
                .Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open();
            var i = 0;
            int nr = 0;
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
            Console.WriteLine($"Processo di creazione della tabella \"{sqlScriptName.Substring(0, sqlScriptName.IndexOf('.'))}\" terminato con {i} error{(i == 1 ? "e" : "i")}.");
            System.Threading.Thread.Sleep(3500);
            con.Close();
        }
    }
}