using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2201737324.View
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                homeLogin.Visible = false;
            }
            else if (Session["member"] != null)
            {
                homeLogin.Visible = false;
                LinkUser.Visible = false;
                LinkType.Visible = false;
            }
            else if (Session["admin"] == null && Session["member"] == null)
            {
                homeLogout.Visible = false;
                LinkProfile.Visible = false;
                LinkType.Visible = false;
                LinkUser.Visible = false;
            }
        }

        protected void homeLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void homeLogout_Click(object sender, EventArgs e)
        {
            if(Session["admin"] != null)
            {
                Session.Remove("admin");
                HttpCookie cookieAdmin = Response.Cookies.Get("admin");
                cookieAdmin.Expires = DateTime.Now.AddHours(-1);
            }
            else if(Session["member"] != null)
            {
                Session.Remove("member");
                HttpCookie cookieMember = Response.Cookies.Get("member");
                cookieMember.Expires = DateTime.Now.AddHours(-1);
            }
            Response.Redirect("HomePage.aspx");
        }
    }
}