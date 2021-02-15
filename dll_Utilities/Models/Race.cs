using System;
using System.Data.SqlClient;

namespace dll_Utilities.Models
{
    public class Race
    {
        public int id { get; set; }
        public int circuitId { get; set; }
        public DateTime date { get; set; }

		public Race(int id, int circuitId, DateTime date)
		{
			this.id = id;
			this.circuitId = circuitId;
			this.date = date;
		}

		public Race(SqlDataReader reader)
        {
            this.id = int.Parse(reader.GetString(0));
            this.circuitId = int.Parse(reader.GetString(1));
            this.date = DateTime.Parse(reader.GetString(2));
        }
    }
}