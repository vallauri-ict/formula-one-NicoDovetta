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
    public class RaceController : ControllerBase
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        Utilities_Database db = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        [Route("api/races/")]
        public List<dll_Utilities.Models.Race> Get()
        {
            return db.getRacesElementList();
        }

        [Route("api/dto-races/")]
        public List<dll_Utilities.dtoModels.dtoRace> GetDto()
        {
            return db.getDtoRace();
        }

        [Route("api/races/{id}")]
        public dll_Utilities.Models.Race Get(int id)
        {
            return db.getRaceByCode(id);
        }
    }
}