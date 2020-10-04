using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2201737324.Model;
using Assignment_2201737324.Factory;

namespace Assignment_2201737324.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["admin"] != null && Session["member"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }
        
        protected void loginUser(object sender, EventArgs e)
        {           
            string emailVar = email.Text;
            string passVar = password.Text;

            TokobediaModelContainer db = new TokobediaModelContainer();
            User users = db.Users.Where(a => a.Email == emailVar).Where(a => a.Password == passVar).FirstOrDefault();

            if(users == null)
            {
                errorMsg.Text = "Wrong Email/Password!";
            }
            else if(users.Status == 2)
            {
                errorMsg.Text = "Your account is banned. Contact administrator for further information";
            }
            else if(users!=null && users.Status == 1)
            {
                if(users.RoleId == 1)
                {
                    Session.Add("admin", users);
                    if (rememberMe.Checked)
                    {
                        HttpCookie cookieAdmin = new HttpCookie("admin", users.Id.ToString());
                        cookieAdmin.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookieAdmin);
                    }
                }
                else if(users.RoleId == 2)
                {
                    Session.Add("member", users);
                    if (rememberMe.Checked)
                    {
                        HttpCookie cookieMember = new HttpCookie("member", users.Id.ToString());
                        cookieMember.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookieMember);
                    }
                }
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}