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
            if (Page.IsPostBack)
            {
                //Eseguito sempre, tranne la prima volta che la pagina viene creata.
                //Eleborazioni da eseguire tutte le volte che la pagina viene caricata.
                ////lblMessaggio.Text = $"Benvenuto sig. {txtUserName.Text}";

                //Riempiamo la lista delle nazioni
            }
            else
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
            dataTable.DataSource = dbManager.getTableElement(lstTable.SelectedValue);
            dataTable.DataBind();
        }
	}
}