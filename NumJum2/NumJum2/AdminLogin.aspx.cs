using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumJum2
{
    public partial class AdminLogin : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // If user is admin, navigate to the managment page
            if (Membership.ValidateUser(LoginUser.UserName, LoginUser.Password))
            {

                bool isRole = Roles.IsUserInRole(LoginUser.UserName, "admin");

                // Only allow in if 'admin' Role
                if (isRole)
                {
                    FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                }
            } 
        }
    }
}