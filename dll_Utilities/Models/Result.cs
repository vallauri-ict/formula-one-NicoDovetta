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
            this.id = int.Parse(reader.GetString(0));
            this.raceId = int.Parse(reader.GetString(1));
            this.driverId = int.Parse(reader.GetString(2));
            this.fastestLap = DateTime.Parse(reader.GetString(3));
            this.position = reader.GetString(4);
        }
    }
}