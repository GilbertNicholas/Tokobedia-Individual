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
    public partial class UpdateProdTypePage : System.Web.UI.Page
    {
        TokobediaModelContainer database = new TokobediaModelContainer();
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Session["admin"] == null)
            {
                if (Request.Cookies.Get("admin") != null)
                {
                    HttpCookie cookieAdmin = Request.Cookies.Get("admin");
                    int id = int.Parse(cookieAdmin.Value); 
                    User users = database.Users.Where(a => a.Id == id).FirstOrDefault();

                    Session.Add("admin", users);
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
            if (!IsPostBack)
            {
                int prodId = Int32.Parse(Request.QueryString["id"]);
                ProductType types = database.ProductTypes.Where(a => a.Id == prodId).FirstOrDefault();
                nameType.Text = types.Name.ToString();
                desc.Text = types.Description.ToString();
            }
        }

        protected void updateType(object sender, EventArgs e)
        {
            string newName = nameType.Text.ToString();
            string newDesc = desc.Text.ToString();
            int id = Int32.Parse(Request.QueryString["id"]);

            ProductType types = database.ProductTypes.Where(a => a.Name == newName).FirstOrDefault();

            if (types != null || newName != types.Name)
            {
                errorMsg.Text = "Type Name has been registered!";
            }
            else
            {
                TypeRepository.updateType(id, newName, newDesc);

                successMsg.Text = "Update Success!";
            }
        }
    }
}