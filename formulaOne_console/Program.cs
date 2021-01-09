using System;
using System.IO;
using dll_Utilities;


namespace formulaOne_console
{
    class Program
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        private static Utilities_Database dbManager = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        private static void menu()
        {
            Console.Clear();
            Console.Title = "Formula one - Batch operations";
            Console.WriteLine("*** Formula one - Batch operations ***");
            Console.WriteLine("1 - Execute import countries table;");
            Console.WriteLine("2 - Execute import teams table;");
            Console.WriteLine("3 - Execute import drivers table;");
            Console.WriteLine("4 - Show countries table elements;");
            Console.WriteLine("5 - Show teams table elements;");
            Console.WriteLine("6 - Show drivers table elements;");
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
                        dbManager.ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        dbManager.ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        dbManager.ExecuteSqlScript("Drivers.sql");
                        break;
                    case '4':
                        show("countries");
                        break;
                    case '5':
                        show("teams",25);
                        break;
                    case '6':
                        show("drivers",18);
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

        /// <summary>
        /// Esegue il display a video della tabella scelta.
        /// </summary>
        /// <param name="tableName">Nome della tabella da visualizzare</param>
        /// <param name="nChar">Numero di caratteri riservati per ogni campo</param>
		private static void show(string tableName, int nChar = 10)
		{
            Console.Clear();
            using(System.Data.DataTable dt = dbManager.getTableElement(tableName))
			{
				foreach (System.Data.DataRow row in dt.Rows)
				{
					foreach (var item in row.ItemArray)
					{
						if (!item.ToString().Contains("System."))
						{
                            DateTime date;
                            string aus = item.ToString();
                            if (DateTime.TryParse(item.ToString(),out date))
							{
                                aus = $"{date.Day}/{date.Month}/{date.Year}";
							}
                            Console.Write(String.Format("| {0,-" + nChar + "}", aus));
                        }
                        else
						{
                            //Con il meno davanti al numero allinea a sinistra, altrimenti allinea a destra
                            Console.Write(String.Format("| {0,-" + nChar + "}", "img unavaiable"));
                        }                       
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n\nPress any button to return to the start menù");
            Console.ReadKey();
        }
	}
}