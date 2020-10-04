using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2201737324.Model;
using Assignment_2201737324.Repository;

namespace Assignment_2201737324.View
{
    public partial class ChangePwPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["member"] == null)
            {
                if (Request.Cookies.Get("admin") != null)
                {
                    HttpCookie cookieAdmin = Request.Cookies.Get("admin");
                    int id = int.Parse(cookieAdmin.Value);
                    TokobediaModelContainer db = new TokobediaModelContainer();
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();

                    Session.Add("admin", users);
                }
                else if (Request.Cookies.Get("member") != null)
                {
                    HttpCookie cookieMember = Request.Cookies.Get("member");
                    int id = int.Parse(cookieMember.Value);
                    TokobediaModelContainer db = new TokobediaModelContainer();
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();

                    Session.Add("member", users);
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        protected void submitChange(object sender, EventArgs e)
        {
            TokobediaModelContainer db = new TokobediaModelContainer();

            string oldPass = OldPassword.Text;
            string newPass = ConfirmPassword.Text;

            string emailVar = ((User)Session["updatePw"]).Email;
            User users = db.Users.Where(a => a.Email == emailVar).Where(a => a.Password == oldPass).FirstOrDefault();

            if (users != null)
            {
                UserRepository.updateUserPassword(emailVar, newPass);
                successMsg.Text = "Success!";
            }
            else
            {
                errorMsg.Text = "Incorrect Password!";
            }
        }
    }
}