using System.Data.SqlClient;

namespace dll_Utilities.Models
{
    public class Circuit
    {
        public int id { get; set; }
        public string countryCode { get; set; }
        public string place { get; set; }
        public string name { get; set; }
        public int laps { get; set; }

		public Circuit(int id, string countryCode, string place, string name, int laps)
		{
			this.id = id;
			this.countryCode = countryCode;
			this.place = place;
			this.name = name;
			this.laps = laps;
		}

		public Circuit(SqlDataReader reader)
        {
            this.id = reader.GetInt32(0);
            this.countryCode = reader.GetString(1);
            this.place = reader.GetString(2);
            this.name = reader.GetString(3);
            this.laps = reader.GetInt32(4);
        }
    }
}