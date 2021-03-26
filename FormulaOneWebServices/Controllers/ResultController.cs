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

        // GET: api/Country
        [HttpGet]
        public List<dll_Utilities.Models.Result> Get()
        {
            return db.getResultsElementList();
        }
    }
}