using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dll_Utilities;
using System.Data;

namespace FormulaOneWebServices
{
    public class CountryController : ControllerBase
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        Utilities_Database db = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        [Route("api/countries/")]
        public List<dll_Utilities.Models.Country> Get()
        {
            return db.getCountryElementList();
        }

        [Route("api/dto-countries/")]
        public List<dll_Utilities.dtoModels.dtoCountry> GetDto()
        {
            return db.getDtoCountries();
        }

        [Route("api/countries-isoCode/{iscoCode}")]
        public dll_Utilities.Models.Country Get(string isoCode)
        {
            return db.getCountryByCode(isoCode);
        }

        [Route("api/countries-namme/{name}")]
        public List<dll_Utilities.Models.Country> GetName(string name)
        {
            if (name.Contains('_'))
            {
                name = name.Replace('_', ' ');
            }
            return db.getCountryByName(name);
        }
    }
}