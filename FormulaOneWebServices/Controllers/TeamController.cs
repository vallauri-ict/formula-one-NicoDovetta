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
    [ApiController]
    public class TeamController : ControllerBase
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        Utilities_Database db = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        [Route("api/teams")]
        [HttpGet]
        public List<dll_Utilities.Models.Team> Get()
        {
            return db.getTeamsElementList();
        }

        [Route("dto/teams/")]
        [HttpGet]
        public List<dll_Utilities.dtoModels.dtoTeam> GetDto()
        {
            return db.getDtoTeams();
        }

        [Route("api/teams/id/{id}")]
        [HttpGet("{id}")]
        public dll_Utilities.Models.Team Get(int id)
        {
            return db.getTeamByCode(id);
        }

        [Route("api/teams/name/{name}")]
        [HttpGet("{name}")]
        public dll_Utilities.Models.Team Get(string name)
        {
			if (name.Contains('_'))
			{
                name = name.Replace('_', ' ');
			}
            return db.getTeamByName(name);
        }
    }
}