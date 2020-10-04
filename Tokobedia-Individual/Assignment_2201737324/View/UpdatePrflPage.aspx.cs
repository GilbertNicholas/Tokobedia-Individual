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
    public partial class UpdatePrflPage : System.Web.UI.Page
    {
        static TokobediaModelContainer db = new TokobediaModelContainer();
        User isUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["member"] == null)
            {
                if (Request.Cookies.Get("admin") != null)
                {
                    HttpCookie cookieAdmin = Request.Cookies.Get("admin");
                    int id = int.Parse(cookieAdmin.Value);
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();

                    Session.Add("admin", users);
                }
                else if (Request.Cookies.Get("member") != null)
                {
                    HttpCookie cookieMember = Request.Cookies.Get("member");
                    int id = int.Parse(cookieMember.Value);
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();

                    Session.Add("member", users);
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }

            isUser = ((User)Session["updatePrfl"]);
            if (isUser != null && !IsPostBack)
            {
                email.Text = isUser.Email.ToString();
                name.Text = isUser.Name.ToString();
                if (isUser.Gender.Equals("Male")) radioGender.SelectedIndex = 0;
                else if (isUser.Gender.Equals("Female")) radioGender.SelectedIndex = 1;
            }          
        }

        protected void submitUpdate(object sender, EventArgs e)
        {
            string newEmail = email.Text;
            string newName = name.Text;
            string newGender = radioGender.Text;

            User users = db.Users.Where(a => a.Email == newEmail).FirstOrDefault();

            if(Session["admin"]!=null)
            {
                int userId = ((User)Session["admin"]).Id;
                if (users != null && newEmail != users.Email)
                {
                    errorMsg.Text = "Your email has been registered!";
                }
                else
                {
                    UserRepository.updateUserInfo(newEmail, newName, newGender, userId);

                    successMsg.Text = "Update Success!";
                }
            }
            else if(Session["member"]!=null)
            {
                int userId = ((User)Session["member"]).Id;
                if (users != null && newEmail != users.Email)
                {
                    errorMsg.Text = "Your email has been registered!";
                }
                else
                {
                    UserRepository.updateUserInfo(newEmail, newName, newGender, userId);

                    successMsg.Text = "Update Success!";
                }
            }
            
        }
    }
}