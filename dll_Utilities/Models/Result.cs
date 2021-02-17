using System;
using System.Data.SqlClient;

namespace dll_Utilities.Models
{
    public class Result
    {
        public int id { get; set; }
        public int raceId { get; set; }
        public int driverId { get; set; }
        public DateTime fastestLap { get; set; }
        public string position { get; set; }

		public Result(int id, int raceId, int driverId, DateTime fastestLap, string position)
		{
			this.id = id;
			this.raceId = raceId;
			this.driverId = driverId;
			this.fastestLap = fastestLap;
			this.position = position;
		}

		public Result(SqlDataReader reader)
        {
            this.id = reader.GetInt32(0);
            this.raceId = reader.GetInt32(1);
            this.driverId = reader.GetInt32(2);
            this.fastestLap = reader.GetDateTime(3);
            this.position = reader.GetString(4);
        }
    }
}