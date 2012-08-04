using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NumJum2.Services.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NumJum2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            using (var dbContext = new PlayerDbContext())
            {
                if (!dbContext.Database.Exists())
                {
                    dbContext.Database.Create();
                }

                dbContext.Dispose();
            }


        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}