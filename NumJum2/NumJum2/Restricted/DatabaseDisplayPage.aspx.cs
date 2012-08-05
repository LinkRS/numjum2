using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NumJum2.Restricted
{
    public partial class DatabaseDisplayPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected SqlConnection GetConnection()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["PlayerDbContext"].ConnectionString;

            return new SqlConnection(connectionString);
        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            // Logout user
            FormsAuthentication.SignOut();

            // Return to Main Menu
            Response.Redirect("..\\Default.aspx");
        }
    }
}