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
            this.id = reader.GetInt32(0);
            this.circuitId = reader.GetInt32(1);
            this.date = reader.GetDateTime(2);
        }
    }
}