using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using dll_Utilities.Models;

namespace dll_Utilities.dtoModels
{
	public class dtoRace
	{
		private int raceId;
		private int circuitId;
		private DateTime date;

		public int RaceId { get => raceId; set => raceId = value; }
		public int CircuitId { get => circuitId; set => circuitId = value; }
		public DateTime Date { get => date; set => date = value; }

		public dtoRace(int raceId, int circuitId, DateTime date)
		{
			RaceId = raceId;
			CircuitId = circuitId;
			Date = date;
		}

		public dtoRace(SqlDataReader reader)
		{
			RaceId = reader.GetInt32(0);
			CircuitId = reader.GetInt32(1);
			date = reader.GetDateTime(2);
		}
	}
}