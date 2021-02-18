using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dll_Utilities.Models
{
	public class dtoDriver
	{
		public int driverId { get; set; }
		public string countryCode { get; set; }
		public string fullImg { get; set; }
		public string fullName { get; set; }
		public string teamName { get; set; }

		public dtoDriver(int driverId, string countryCode, string fullImg, string fullName, string teamName)
		{
			this.driverId = driverId;
			this.countryCode = countryCode;
			this.fullImg = fullImg;
			this.fullName = fullName;
			this.teamName = teamName;
		}

		public dtoDriver(SqlDataReader reader)
		{
			this.driverId = reader.GetInt32(0);
			this.countryCode = reader.GetString(1);
			this.fullImg = reader.GetString(2);
			this.fullName = reader.GetString(3);
			this.teamName = reader.GetString(4);
		}
	}
}
