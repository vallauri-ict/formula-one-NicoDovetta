using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

		protected void apiSel_SelectedIndexChanged(object sender, EventArgs e)
		{
            makeRequest(apiSel.SelectedItem.ToString());
        }

        private void makeRequest(string param="")
		{
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44320/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (apiFilter.Text != "")
            {
                param += "/" + apiFilter.Text;
            }

            // List data response.
            HttpResponseMessage response = client.GetAsync(param).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                string dataObjects = response.Content.ReadAsStringAsync().Result.ToString();
                string aus = dataObjects.Remove(0, 1);
                aus = aus.Remove(dataObjects.Length - 2);
                string[] msg = aus.Split('}');
                visual.DataSource = msg;
                visual.DataBind();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }

		protected void btnFilter_Click(object sender, EventArgs e)
		{
            makeRequest(apiSel.SelectedItem.ToString() + "/" + apiFilter.Text);
		}
	}
}