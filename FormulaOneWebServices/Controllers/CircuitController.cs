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
    public class CircuitController : ControllerBase
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        Utilities_Database db = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        [Route("api/circuits/")]
        public List<dll_Utilities.Models.Circuit> Get()
        {
            return db.getCircuitsElementList();
        }

        [Route("api/dto-circuits/")]
        public List<dll_Utilities.dtoModels.dtoCountry> GetDto()
        {
            return db.getDtoCircuits();
        }

        [Route("api/circuit/{id}")]
        public dll_Utilities.Models.Circuit Get(int id)
        {
            return db.getCircuitByCode(id)
        }

        [Route("api/circuits/{name}")]
        public List<dll_Utilities.Models.Circuit> GetName(string name)
        {
            if (name.Contains('_'))
            {
                name = name.Replace('_', ' ');
            }
            return db.getcircuitByName(name);
        }
    }
}