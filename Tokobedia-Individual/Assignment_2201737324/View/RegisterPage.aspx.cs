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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["member"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        static TokobediaModelContainer db = new TokobediaModelContainer();

        protected void registerUser(object sender, EventArgs e)
        {
            string getEmail = email.Text.ToString();
            string getName = name.Text.ToString();
            string getPassword = cpassword.Text.ToString();
            string getGender = radioGender.Text.ToString();

            User users = db.Users.Where(a => a.Email == getEmail).FirstOrDefault();

            if(users != null)
            {
                errorMsg.Text = "Your email has been registered!";

            }
            else
            {
                UserRepository.insertUser(getEmail, getName, getPassword, getGender);
                
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}