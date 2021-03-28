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
    public class ResultController : ControllerBase
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        Utilities_Database db = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        [Route("api/results/")]
        public List<dll_Utilities.Models.Result> Get()
        {
            return db.getResultsElementList();
        }

        [Route("api/results/{id}")]
        public dll_Utilities.Models.Result Get(int id)
		{
            return db.getResultByCode(id);
		}

        [Route("api/results/driver/{id}")]
        public List<dll_Utilities.Models.Result> Get_D(int id)
        {
            return db.getResultByDriver(id);
        }

        [Route("api/results/race/{id}")]
        public List<dll_Utilities.Models.Result> Get_R(int id)
        {
            return db.getResultByRace(id);
        }

        [Route("api/results/team/{id}")]
        public List<dll_Utilities.Models.Result> Get_T(int id)
        {
            return db.getResultByTeam(id);
        }
    }
}