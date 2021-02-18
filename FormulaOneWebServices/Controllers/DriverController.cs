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
    public class DriverController : ControllerBase
    {
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        Utilities_Database db = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        [Route("api/driver/")]
        //[Route("api/driver/all")]
        [HttpGet]
        public List<dll_Utilities.Models.Driver> Get()
        {
            return db.getDriverElementList();
        }

        [Route("api/driver/mixed")]
        [HttpGet]
        public List<dll_Utilities.> mix()
        {
            return db.getDtoDrivers();
        }

        [Route("api/driver/{id}")]
        [HttpGet]
        public dll_Utilities.Models.Driver Get(int id)
        {
            return db.getDriverByCode(id);
        }

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}