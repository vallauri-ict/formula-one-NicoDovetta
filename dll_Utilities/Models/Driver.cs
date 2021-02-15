using System;
using System.Data.SqlClient;
using System.Drawing;

namespace dll_Utilities.Models
{
    public class Driver
    {
        public int id { get; set; }
        public string countryCode { get; set; }
        public Image helmetImg { get; set; }
        public Image fullImg { get; set; }
        public string fullName { get; set; }
        public int podiums { get; set; }
        public int points { get; set; }
        public DateTime dob { get; set; }
        public string pob { get; set; }

		public Driver(int id, string countryCode, Image helmetImg, Image fullImg, string fullName, int podiums, int points, DateTime dob, string pob)
		{
			this.id = id;
			this.countryCode = countryCode;
			this.helmetImg = helmetImg;
			this.fullImg = fullImg;
			this.fullName = fullName;
			this.podiums = podiums;
			this.points = points;
			this.dob = dob;
			this.pob = pob;
		}

		public Driver(SqlDataReader reader)
        {
			this.id = int.Parse(reader.GetString(0));
			this.countryCode = reader.GetString(1);
			this.helmetImg = Image.FromFile(reader.GetString(2));
			this.fullImg = Image.FromFile(reader.GetString(3));
			this.fullName = reader.GetString(4);
			this.podiums = int.Parse(reader.GetString(5));
			this.points = int.Parse(reader.GetString(6));
			this.dob = DateTime.Parse(reader.GetString(7));
			this.pob = reader.GetString(8);
		}
    }
}