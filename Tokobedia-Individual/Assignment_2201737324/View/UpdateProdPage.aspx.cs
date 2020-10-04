using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2201737324.Repository;
using Assignment_2201737324.Model;

namespace Assignment_2201737324.View
{
    public partial class UpdateProdPage : System.Web.UI.Page
    {
        static TokobediaModelContainer db = new TokobediaModelContainer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                if (Request.Cookies.Get("admin") != null)
                {
                    HttpCookie cookieAdmin = Request.Cookies.Get("admin");
                    int id = int.Parse(cookieAdmin.Value);
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();

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
                Product products = db.Products.Where(a => a.Id == prodId).FirstOrDefault();
                nameProd.Text = products.Name.ToString();
                stockProd.Text = products.Stock.ToString();
                priceProd.Text = products.Price.ToString();

                int type = products.ProductTypeID;
                ProductType types = db.ProductTypes.Where(a => a.Id == type).FirstOrDefault();

                typeIdProd.Text = types.Name;
            }
        }

        

        protected void updateProduct(object sender, EventArgs e)
        {
            string newName = nameProd.Text.ToString();
            int stock = Int32.Parse(stockProd.Text.ToString());
            int price = Int32.Parse(priceProd.Text.ToString());
            string typeId = typeIdProd.Text.ToString();
            int id = Int32.Parse(Request.QueryString["id"]);

            ProductType types = db.ProductTypes.Where(a => a.Name == typeId).FirstOrDefault();
            if (types == null)
            {
                errorMsg.Text = "Invalid Product Type Name";
            }
            else if (price % 1000 != 0 || price <= 1000) errorMsg.Text = "Price must be above 1000 and multiply of 1000";

            else if (stock < 1) errorMsg.Text = "Stock must be 1 or more";
            else
            {
                int newTypeId = types.Id;
                ProductRepository.updateProductInfo(id, newName, price, stock, newTypeId);

                successMsg.Text = "Success!";
            }
        }
    }
}