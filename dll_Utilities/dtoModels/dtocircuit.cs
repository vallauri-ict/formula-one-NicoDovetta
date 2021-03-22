using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace dll_Utilities.dtoModels
{
	public class dtoCircuit
	{
        private int id;
        private string countryCode;
        private string place;
        private string name;
        private int laps;

        public int Id { get => id; set => id = value; }
        public string CountryCode { get => countryCode; set => countryCode = value; }
        public string Place { get => place; set => place = value; }
        public string Name { get => name; set => name = value; }
        public int Laps { get => laps; set => laps = value; }

        public dtoCircuit(int id, string countryCode, string place, string name, int laps)
        {
            this.Id = id;
            this.CountryCode = countryCode;
            this.Place = place;
            this.Name = name;
            this.Laps = laps;
        }

        public dtoCircuit(SqlDataReader reader)
        {
            this.Id = reader.GetInt32(0);
            this.CountryCode = reader.GetString(1);
            this.Place = reader.GetString(2);
            this.Name = reader.GetString(3);
            this.Laps = reader.GetInt32(4);
        }
    }
}
