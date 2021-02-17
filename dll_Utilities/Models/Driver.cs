using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;

namespace dll_Utilities.Models
{
    public class Driver
    {
        public int id { get; set; }
        public string countryCode { get; set; }
        public string helmetImg { get; set; }
        public string fullImg { get; set; }
        public string fullName { get; set; }
        public int podiums { get; set; }
        public int points { get; set; }
        public DateTime dob { get; set; }
        public string pob { get; set; }

		public Driver(int id, string countryCode, string helmetImg, string fullImg, string fullName, int podiums, int points, DateTime dob, string pob)
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
			this.id = reader.GetInt32(0);
			this.countryCode = reader.GetString(1);
			this.helmetImg = reader.GetString(2);
			this.fullImg = reader.GetString(3);
			this.fullName = reader.GetString(4);
			this.podiums = reader.GetInt32(5);
			this.points = reader.GetInt32(6);
			this.dob = reader.GetDateTime(7).Date;//DateTime.Parse(reader.GetString(7));
			this.pob = reader.GetString(8);
		}

		private Image stringToImage(string inputString)
		{
			byte[] imageBytes = Encoding.Unicode.GetBytes(inputString);

			// Don't need to use the constructor that takes the starting offset and length
			// as we're using the whole byte array.
			MemoryStream ms = new MemoryStream(imageBytes);

			Image image = Image.FromStream(ms, true, true);

			return image;
		}
	}
}