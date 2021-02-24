using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                    Console.WriteLine("Query execution error in query number: " + i);
                    Console.WriteLine("\tError SQL: " + err.Number + " - " + err.Message);
                    Console.WriteLine("\nPress any button to continue.");
                    Console.ReadKey();
                    nr++;
                }
            }

            Console.Clear();
            Console.WriteLine($"Query execution completed with {nr} error{(nr == 1 ? "" : "s")}.");
            Console.ReadKey();
            con.Close();
        }

        public void Backup()
        {
            Console.Clear();
            string bckName = "";
            bool ok = true;
            char c;

            //Nome al backup
            do
            {
                Console.Write("Personalize backup name? (Y/N) ");
                c = Char.ToLower(Console.ReadKey().KeyChar);
                switch (c)
                {
                    case 'y':
						{
                            Console.Clear();
                            bool nameOk = false;
                            do
                            {
                                Console.WriteLine("Insert backup name");
                                bckName = Console.ReadLine();
                                if (bckName.Contains(".bak") || bckName.Contains("/") || bckName.Contains(":") || bckName == "")
                                {
                                    Console.WriteLine("Name not valid.");
                                    Thread.Sleep(100);
                                    nameOk = false;
                                }
                                else
                                {
                                    nameOk = true;
                                }
                            } while (File.Exists($@"{WORKINGPATH1}backup\{bckName}.bak") && !nameOk);
                            break;
                        }
                    case 'n':
                        bckName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                        break;
                    default:
                        Console.WriteLine("Make another selection.");
                        break;
                }
            } while (c != 'y' && c != 'n');

            //Controllo univocità nome backup
            if (File.Exists($@"{WORKINGPATH1}backup\{bckName}.bak"))
			{
                ok = false;
                do
                {
                    Console.Clear();
                    Console.Write($"A backup named:\"{bckName}\" already exist. Overwrite it? (Y/N) ");
                    c = Char.ToLower(Console.ReadKey().KeyChar);
                    switch (c)
                    {
                        case 'y':
                            ok = true;
                            File.Delete($@"{WORKINGPATH1}backup\{bckName}.bak");
                            break;
                        case 'n':
                            Console.WriteLine("Return to main menu.");
                            break;
                        default:
                            Console.WriteLine("Make another selection.");
                            break;
                    }
                } while (c != 'y' && c != 'n');
            }

            //Creazione del backup
			if (ok)
			{
                try
                {
                    using (SqlConnection dbConn = new SqlConnection())
                    {
                        dbConn.ConnectionString = CONNECTION_STRING;
                        dbConn.Open();

                        using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                        {
                            multiuser_rollback_dbcomm.Connection = dbConn;
                            multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [C:\data\formulaOne\formulaOne.mdf] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                            multiuser_rollback_dbcomm.ExecuteNonQuery();
                        }
                        dbConn.Close();
                    }

                    SqlConnection.ClearAllPools();

                    using (SqlConnection backupConn = new SqlConnection())
                    {
                        backupConn.ConnectionString = CONNECTION_STRING;
                        backupConn.Open();

                        using (SqlCommand backupcomm = new SqlCommand())
                        {
                            backupcomm.Connection = backupConn;
                            backupcomm.CommandText = $@"BACKUP DATABASE [C:\data\formulaOne\formulaOne.mdf] TO DISK='{WORKINGPATH1}\backup\{bckName}.bak'";
                            backupcomm.ExecuteNonQuery();
                        }
                        backupConn.Close();
                    }
                    Console.WriteLine("Backup procedure completed succesfully. Return to main menu.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Thread.Sleep(1000);
        }

		public void RestoreDefault()
		{
            Console.Clear();
            //Restoring db to default
            bool _ = ExecuteScript("removeForeign.sql");
			if (ExecuteScript("DropTable.sql"))
			{
				if (ExecuteScript("Countries.sql"))
				{
					if (ExecuteScript("Teams.sql"))
					{
                        if (ExecuteScript("Drivers.sql"))
                        {
                            if (ExecuteScript("Circuits.sql"))
                            {
                                if (ExecuteScript("Races.sql"))
                                {
                                    if (ExecuteScript("Results.sql"))
                                    {
										if (ExecuteScript("foreignKeys.sql"))
										{
                                            Console.WriteLine("DataBase restored. Return to main menu");
                                            Thread.Sleep(1000);
                                        }
                                        else
										{
                                            error();
										}
                                    }
                                    else
                                    {
                                        error();
                                    }
                                }
                                else
                                {
                                    error();
                                }
                            }
                            else
                            {
                                error();
                            }
                        }
                        else
                        {
                            error();
                        }
                    }
                    else
                    {
                        error();
                    }
                }
                else
                {
                    error();
                }
            }
            else
            {
                error();
            }
        }

		private void error()
		{
            char aus;
            do
            {
                Console.Clear();
                Console.Write("An error occourred. Start restore DB backup procedure? (Y/N) ");
                aus = Char.ToLower(Console.ReadKey().KeyChar);
                switch (aus)
                {
                    case 'y':
                        Restore();
                        break;
                    default:
                        break;
                }
            } while (aus != 'y' && aus != 'n');
        }

		private bool ExecuteScript(string scriptName)
		{
            bool ret = true;
            string fileContent = File.ReadAllText(WORKINGPATH1 + scriptName);
            fileContent = fileContent.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            SqlConnection con = new SqlConnection(CONNECTION_STRING1);
            SqlCommand cmd = new SqlCommand("query", con);
            con.Open();
            foreach (var query in sqlqueries)
			{
				try
				{
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
				catch (SqlException exc)
				{
                    ret= false;
				}
            }
            con.Close();
            return ret;
        }

		public void Restore()
        {
            string bckPath = getBackupName();
			if (bckPath != "n/a")
			{
                try
                {
                    using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                    {
                        con.Open();
                        string sqlStmt2 = string.Format($@"ALTER DATABASE [C:\data\formulaOne\formulaOne.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                        SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                        bu2.ExecuteNonQuery();

                        string sqlStmt3 = $@"USE MASTER RESTORE DATABASE [C:\data\formulaOne\formulaOne.mdf] FROM DISK='{bckPath}' WITH REPLACE;";
                        SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                        bu3.ExecuteNonQuery();

                        string sqlStmt4 = string.Format($@"ALTER DATABASE [C:\data\formulaOne\formulaOne.mdf] SET MULTI_USER");
                        SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                        bu4.ExecuteNonQuery();
                        con.Close();

                        Console.Clear();
                        Console.WriteLine("Database ripristinated correctly. Return to main menu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
			{
                Console.Clear();
                Console.WriteLine("No backup file found. Return to main menu.");
			}
            Thread.Sleep(1000);
        }

		private string getBackupName()
		{
            string[] filePaths = Directory.GetFiles($@"{WORKINGPATH1}\backup\", "*.bak");
            filePaths.Reverse();
			if (filePaths.Length > 0)
			{
                int pos = -1;
                string name;
                do
                {
                    Console.Clear();
                    foreach (string item in filePaths)
                    {
                        Console.WriteLine($"{item.Substring(item.LastIndexOf('\\') + 1)}");

                    }
                    Console.WriteLine("\nInsert backup file name");
                    name = Console.ReadLine();
                    int i = -1;
                    foreach (string item in filePaths)
                    {
                        i++;
                        if (item.Contains(name))
                        {
                            pos = i;
                        }
                    }
                } while (pos == -1);
                return filePaths[pos];
            }
            else
			{
                return "n/a";
			}
        }

		public void getTableName(ref List<string> tableName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("query", con);
            con.Open();

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
                Console.WriteLine("\tError SQL: " + err.Number + " - " + err.Message);
                Console.ReadKey();
            }
            con.Close();
        }

        public DataTable getTableElement(string tbName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
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
                    connection.Close();
                }
            }
            return dt;
        }

        public List<string> getTableName()
        {
            List<string> tbName = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
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
                    connection.Close();
                }
            }
            return tbName;
        }

        public List<Models.Circuit> getCircuitsElementList()
        {
            List<Models.Circuit> retVal = new List<Models.Circuit>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Circuits;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new Models.Circuit(reader));
                        }
                    }
                }
            }
            return retVal;
        }


        public Models.Circuit getCircuitByCode(int code)
        {
            Models.Circuit retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Circuits WHERE Circuit_id = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Circuit(reader);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Country> getCountryElementList()
        {
            List<Models.Country> retVal = new List<Models.Country>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Countries;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    
                    // create data adapter
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            retVal.Add(new Models.Country(reader));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Country getCountryByCode(string code)
        {
            Models.Country retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Countries WHERE CountryCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Country(reader);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Driver> getDriverElementList()
        {
            List<Models.Driver> retVal = new List<Models.Driver>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Drivers;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new Models.Driver(reader));
                        }
                    }
                }
            }
            return retVal;
        }

        public List<dtoModels.dtoDriver> getDtoDrivers()
		{
            List<dtoModels.dtoDriver> retVal = new List<dtoModels.dtoDriver>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"[dbo].[driversDtoData]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new dtoModels.dtoDriver(reader));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Driver getDriverByCode(int code)
        {
            Models.Driver retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Drivers WHERE Driver_id = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Driver(reader);
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Driver getDriverByName(string name)
        {
            Models.Driver retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Drivers WHERE FullName LIKE '{name}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Driver(reader);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Race> getRacesElementList()
        {
            List<Models.Race> retVal = new List<Models.Race>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Races;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new Models.Race(reader));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Race getRaceByCode(int code)
        {
            Models.Race retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Races WHERE Race_id = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Race(reader);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Result> getResultsElementList()
        {
            List<Models.Result> retVal = new List<Models.Result>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Results;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new Models.Result(reader));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Result getResultByCode(int code)
        {
            Models.Result retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Results WHERE Result_id = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Result(reader);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Team> getTeamsElementList()
        {
            List<Models.Team> retVal = new List<Models.Team>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Teams;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new Models.Team(reader));
                        }
                    }
                }
            }
            return retVal;
        }

        public List<dtoModels.dtoTeam> getDtoTeams()
        {
            List<dtoModels.dtoTeam> retVal = new List<dtoModels.dtoTeam>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"[dbo].[teamsDtoData]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new dtoModels.dtoTeam(reader));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Team getTeamByCode(int code)
        {
            Models.Team retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Teams WHERE Team_id = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Team(reader);
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Team getTeamByName(string name)
        {
            Models.Team retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Teams WHERE SmallName LIKE '{name}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal = new Models.Team(reader);
                        }
                    }
                }
            }
            return retVal;
        }
    }
}