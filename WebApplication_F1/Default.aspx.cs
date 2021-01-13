using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dll_Utilities;

namespace WebApplication_F1
{
	public partial class Default : System.Web.UI.Page
	{
        private const string WORKINGPATH = @"C:\data\formulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        private static Utilities_Database dbManager = new Utilities_Database(WORKINGPATH, CONNECTION_STRING);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Inizzializzazioni da effettuare solo al primo caricamento della pagina.
                lblMessaggio.Text = "Select a table name from the listbox below to visualize the element.";
                lstTable.DataSource = dbManager.getTableName();
                lstTable.DataBind();
            }
        }

        protected void loadData(object sender, EventArgs e)
        {
            //DATATABLE object
            System.Data.DataTable dtb = dbManager.getTableElement(lstTable.SelectedValue);
			if (dtb.Rows.Count > 0)
			{
                lblNoData.Text = "";
                dataTable.Visible = true;
                dataTable.DataSource = dtb;
                dataTable.DataBind();
            }
            else
			{
                dataTable.Visible = false;
                lblNoData.Text = "No data found for this table.";
            }
        }
	}
}