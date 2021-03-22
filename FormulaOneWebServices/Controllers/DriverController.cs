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
    public class DriverController : ControllerBase
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        Utilities_Database db = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        [Route("api/drivers/")]
        public List<dll_Utilities.Models.Driver> Get()
        {
            return db.getDriverElementList();
        }

        [Route("api/dto-drivers/")]
        public List<dll_Utilities.dtoModels.dtoDriver> GetDto()
        {
            return db.getDtoDrivers();
        }

        [Route("api/drivers/{id}")]
        public dll_Utilities.Models.Driver Get(int id)
        {
            return db.getDriverByCode(id);
        }

        [Route("api/drivers/{name}")]
        public dll_Utilities.Models.Driver Get(string name)
        {
            name = name.Replace('_', ' ');
            return db.getDriverByName(name);
        }
    }
}