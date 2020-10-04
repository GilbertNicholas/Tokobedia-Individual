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
    public partial class HomePage : System.Web.UI.Page
    {
        TokobediaModelContainer db = new TokobediaModelContainer();
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
                    welcome.Visible = false;
                }
            }
            if (Session["admin"] != null || Session["member"] !=null)
            {
                if (Session["admin"] != null)
                {
                    int id = ((User)Session["admin"]).Id;
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();
                    welcome.Text = "Welcome, " + users.Name;
                }
                else if(Session["member"] != null)
                {
                    int id = ((User)Session["member"]).Id;
                    User users = db.Users.Where(a => a.Id == id).FirstOrDefault();
                    welcome.Text = "Welcome, " + users.Name;
                }
            }
            List<Product> products = ProductRepository.getProducts();

            List<int> cont = new List<int>();
            while (cont.Count < 5)
            {
                Random rand = new Random();
                int idx = rand.Next(0, products.Count-1);

                if (cont.Contains(idx))
                {
                    continue;
                }
                else
                {
                    cont.Add(idx);

                    TableRow rows = new TableRow();
                    productTable.Controls.Add(rows);

                    TableCell idCell = new TableCell();
                    idCell.Controls.Add(new Label()
                    {
                        Text = products[idx].Id.ToString()
                    });
                    rows.Cells.Add(idCell);

                    TableCell typeCell = new TableCell();
                    int typeId = products[idx].ProductTypeID;
                    ProductType types = db.ProductTypes.Where(x => x.Id == typeId).FirstOrDefault();
                    typeCell.Controls.Add(new Label()
                    {
                        Text = types.Name.ToString()
                    });
                    rows.Cells.Add(typeCell);

                    TableCell nameCell = new TableCell();
                    nameCell.Controls.Add(new Label()
                    {
                        Text = products[idx].Name.ToString()
                    });
                    rows.Cells.Add(nameCell);

                    TableCell stockCell = new TableCell();
                    stockCell.Controls.Add(new Label()
                    {
                        Text = products[idx].Stock.ToString()
                    });
                    rows.Cells.Add(stockCell);

                    TableCell priceCell = new TableCell();
                    priceCell.Controls.Add(new Label()
                    {
                        Text = products[idx].Price.ToString()
                    });
                    rows.Cells.Add(priceCell);
                }  
            }
        }
    }
}