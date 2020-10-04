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
    public partial class InsertProdTypePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                if (Request.Cookies.Get("admin") != null)
                {
                    HttpCookie cookieAdmin = Request.Cookies.Get("admin");
                    int id = int.Parse(cookieAdmin.Value);
                    TokobediaModelContainer db = new TokobediaModelContainer();
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();

                    Session.Add("admin", users);
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }
        static TokobediaModelContainer db = new TokobediaModelContainer();

        protected void insertType(object sender, EventArgs e)
        {
            string newName = nameType.Text.ToString();
            string newDesc = desc.Text.ToString();

            ProductType types = db.ProductTypes.Where(a => a.Name == newName).FirstOrDefault();

            if (types != null)
            {
                errorMsg.Text = "Type name has been registered!";
            }
            else
            {
                TypeRepository.insertType(newName, newDesc);

                successMsg.Text = "Success!";
            }
        }
    }
}