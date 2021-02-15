using System.Data.SqlClient;

namespace dll_Utilities.Models
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Country(string countryCode, string countryName)
        {
            this.Code = countryCode;
            this.Name = countryName;
        }

        public Country(SqlDataReader reader)
        {
            this.Code = reader.GetString(0);
            this.Name = reader.GetString(1);
        }
    }
}