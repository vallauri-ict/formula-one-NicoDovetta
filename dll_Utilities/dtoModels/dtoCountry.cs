using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace dll_Utilities.dtoModels
{
	public class dtoCountry
	{
        private string isoCode;
        private string name;

        public string IsoCode { get => isoCode; set => isoCode = value; }
        public string Name { get => name; set => name = value; }


        public dtoCountry(string isoCode, string name)
        {
            this.isoCode = isoCode;
            this.name = name;
        }

        public dtoCountry(SqlDataReader reader)
        {
            this.IsoCode = reader.GetString(0);
            this.Name = reader.GetString(1);
        }
    }
}
