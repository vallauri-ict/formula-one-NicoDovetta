using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace dll_Utilities.dtoModels
{
	public class dtoTeam
	{
		public int id { get; set; }
		public string smallName { get; set; }
		public string smallLogo { get; set; }
		public string carImage { get; set; }
		public string driver1 { get; set; }
		public string driver2 { get; set; }

		public dtoTeam(int id, string smallName, string smallLogo, string carImage, string driver1, string driver2, string img)
		{
			this.id = id;
			this.smallName = smallName;
			this.smallLogo = smallLogo;
			this.carImage = carImage;
			this.driver1 = driver1;
			this.driver2 = driver2;
		}

		public dtoTeam(SqlDataReader reader)
		{
			this.id = reader.GetInt32(0);
			this.smallName = reader.GetString(1);
			this.smallLogo = reader.GetString(2);
			this.carImage = reader.GetString(3);
			this.driver1 = reader.GetString(4);
			this.driver2 = reader.GetString(5);
		}
	}
}
