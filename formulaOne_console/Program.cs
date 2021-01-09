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
                    default:
                        if (c != 'x' && c != 'X')
                        {
                            Console.WriteLine("Effettua un'altra selezione.");
                        }
                        break;
                }
            } while (c != 'x' && c != 'X');
        }
    }
}