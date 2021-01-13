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
            Console.WriteLine("********* Formula one - Batch operations *********");
            Console.WriteLine("\n>>>>>> Create Table");
            Console.WriteLine("1 - Execute import COUNTRIES table;");
            Console.WriteLine("2 - Execute import TEAMS table;");
            Console.WriteLine("3 - Execute import DRIVERS table;");
            Console.WriteLine("4 - Execute import CIRCUITS table;");
            Console.WriteLine("5 - Execute import RACES table;");
            Console.WriteLine("6 - Execute import RESULTS table;");
            Console.WriteLine("\n>>>>>> Show Table");
            Console.WriteLine("7 - Show COUNTRIES table elements;");
            Console.WriteLine("8 - Show TEAMS table elements;");
            Console.WriteLine("9 - Show DRIVERS table elements;");
            Console.WriteLine("a - Show CIRCUITS table elements;");
            Console.WriteLine("c - Show RACES table elements;");
            Console.WriteLine("e - Show RESULTS table elements;");
            Console.WriteLine("\n>>>>>> Backup and restoring");
            Console.WriteLine("b - Create DB backup;");
            Console.WriteLine("r - Restore DB backup;");
            Console.WriteLine("d - Set DB to default values;");
            Console.WriteLine("\n>>>>>> Others");
            Console.WriteLine("f - Execute set relations;");
            Console.WriteLine("u - Execute remove relations;");
            Console.WriteLine("x/X - Exit.");
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
                        dbManager.ExecuteSqlScript("Circuits.sql");
                        break;
                    case '5':
                        dbManager.ExecuteSqlScript("Races.sql");
                        break;
                    case '6':
                        dbManager.ExecuteSqlScript("Results.sql");
                        break;
                    case '7':
                        show("countries");
                        break;
                    case '8':
                        show("teams",25);
                        break;
                    case '9':
                        show("drivers",18);
                        break;
                    case 'a':
                        show("circuits",35);
                        break;
                    case 'c':
                        show("races");
                        break;
                    case 'e':
                        show("results");
                        break;
                    case 'b':
                        dbManager.Backup();
                        break;
                    case 'r':
                        dbManager.Restore();
                        break;
                    case 'd':
						{
                            char aus;
                            do
                            {
                                Console.Clear();
                                Console.Write("Before continuing, would you like to make a DB backup? (Y/N) ");
                                aus = Char.ToLower(Console.ReadKey().KeyChar);
                                switch (aus)
                                {
                                    case 'y':
                                        dbManager.Backup();
                                        break;
                                    default:
                                        break;
                                }
                            } while (aus != 'y' && aus != 'n');
                            dbManager.RestoreDefault();
                        }
                        break;
                    case 'f':
                        dbManager.ExecuteSqlScript("foreignKeys.sql");
                        break;
                    case 'u':
                        dbManager.ExecuteSqlScript("removeForeign.sql");
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
        /*/// <param name="separator">Carattere separatore tra intestazione colonne e dati</param>*/
		private static void show(string tableName, int nChar = 12/*, char separator = '-'*/)
		{
            Console.Clear();
            bool asRow = false;
            using(System.Data.DataTable dt = dbManager.getTableElement(tableName))
			{
                int cCount = 0;
				foreach (System.Data.DataColumn item in dt.Columns)
				{
                    cCount++;
                    Console.Write(String.Format("| {0,-" + nChar + "}", item.ColumnName.ToString()));
                }
                Console.WriteLine();
                /*
                for (int i = 0; i < cCount*nChar; i++)
				{
                    Console.Write(separator);
				}
                Console.WriteLine();
                */
                foreach (System.Data.DataRow row in dt.Rows)
				{
					foreach (var item in row.ItemArray)
					{
						if (!item.ToString().Contains("System."))
						{
                            asRow = true;
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
			if (!asRow)
			{
                Console.WriteLine("No data to display.");
			}
            Console.WriteLine("\n\nPress any button to return to the start menù");
            Console.ReadKey();
        }
	}
}