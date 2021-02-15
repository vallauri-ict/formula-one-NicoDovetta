using System;
using System.Data.SqlClient;
using System.Drawing;

namespace dll_Utilities.Models
{
    public class Team
    {
        public int id { get; set; }
        public int idD1 { get; set; }
        public int idD2 { get; set; }
        public string fullName { get; set; }
        public string smallName { get; set; }
        public Image smallLogo { get; set; }
        public Image fullLogo{ get; set; }
        public Image carImage { get; set; }
        public string baseLocation { get; set; }
        public string countryCode { get; set; }
        public string teamChief { get; set; }
        public string powerUnit { get; set; }
        public int worldChampionships { get; set; }

		public Team(int id, int idD1, int idD2, string fullName, string smallName, Image smallLogo, Image fullLogo, Image carImage, string baseLocation, string countryCode, string teamChief, string powerUnit, int worldChampionships)
		{
			this.id = id;
			this.idD1 = idD1;
			this.idD2 = idD2;
			this.fullName = fullName;
			this.smallName = smallName;
			this.smallLogo = smallLogo;
			this.fullLogo = fullLogo;
			this.carImage = carImage;
			this.baseLocation = baseLocation;
			this.countryCode = countryCode;
			this.teamChief = teamChief;
			this.powerUnit = powerUnit;
			this.worldChampionships = worldChampionships;
		}

		public Team(SqlDataReader reader)
        {
            this.id = int.Parse(reader.GetString(0));
            this.idD1 = int.Parse(reader.GetString(1));
            this.idD2 = int.Parse(reader.GetString(2));
            this.fullName = reader.GetString(3);
            this.smallName = reader.GetString(4);
            this.smallLogo = Image.FromFile(reader.GetString(5));
            this.fullLogo = Image.FromFile(reader.GetString(6));
            this.carImage = Image.FromFile(reader.GetString(7));
            this.baseLocation = reader.GetString(8);
            this.countryCode = reader.GetString(9);
            this.teamChief = reader.GetString(10);
            this.powerUnit = reader.GetString(11);
            this.worldChampionships = int.Parse(reader.GetString(12));
        }
    }
}