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
    public partial class InsertProdPage : System.Web.UI.Page
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

        protected void insertProduct(object sender, EventArgs e)
        {
            string newName = nameProd.Text.ToString();
            int stock = Int32.Parse(stockProd.Text.ToString());
            int price = Int32.Parse(priceProd.Text.ToString());
            string typeName = typeIdProd.Text.ToString();

            ProductType products = db.ProductTypes.Where(a => a.Name == typeName).FirstOrDefault();

            if(products == null)
            {
                errorMsg.Text = "Invalid Product Type Name";
            }
            else if (price % 1000 != 0 || price <= 1000) errorMsg.Text = "Price must be above 1000 and multiply of 1000";

            else if (stock < 1) errorMsg.Text = "Stock must be 1 or more";
            else
            {
                int typeId = products.Id;
                ProductRepository.insertProduct(newName, price, stock, typeId);

                successMsg.Text = "Success!";
            }
        }
    }
}