using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace dll_Utilities.Models
{
    public class Stat
    {
        private int Driver_Id;
        private int TotPoints;
        private decimal avgPoints;
        private int fastLap;
        private int first;
        private int second;
        private int third;
        private int podium;

		public int Driver_Id1 { get => Driver_Id; set => Driver_Id = value; }
		public int TotPoints1 { get => TotPoints; set => TotPoints = value; }
		public decimal AvgPoints { get => avgPoints; set => avgPoints = value; }
		public int FastLap { get => fastLap; set => fastLap = value; }
		public int First { get => first; set => first = value; }
		public int Second { get => second; set => second = value; }
		public int Third { get => third; set => third = value; }
		public int Podium { get => podium; set => podium = value; }

		public Stat(int driver_Id1, int totPoints1, decimal avgPoints, int fastLap, int first, int second, int third, int podium)
		{
			Driver_Id1 = driver_Id1;
			TotPoints1 = totPoints1;
			AvgPoints = avgPoints;
			FastLap = fastLap;
			First = first;
			Second = second;
			Third = third;
			Podium = podium;
		}

		public Stat(SqlDataReader reader)
		{
			Driver_Id1 = reader.GetInt32(0);
			TotPoints1 = reader.GetInt32(1);
			AvgPoints = reader.GetDecimal(2);
			FastLap = reader.GetInt32(3);
			First = reader.GetInt32(4);
			Second = reader.GetInt32(5);
			Third = reader.GetInt32(6);
			Podium = reader.GetInt32(7);
		}
	}
}