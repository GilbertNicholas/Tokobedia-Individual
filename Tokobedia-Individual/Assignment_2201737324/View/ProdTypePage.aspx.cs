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
    public partial class ProdTypePage : System.Web.UI.Page
    {
        TokobediaModelContainer db = new TokobediaModelContainer();
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

            List<ProductType> types = TypeRepository.getTypes();
            for (int i = 0; i < types.Count; i++)
            {
                TableRow rows = new TableRow();
                productTable.Controls.Add(rows);

                TableCell idCell = new TableCell();
                idCell.Controls.Add(new Label()
                {
                    Text = types[i].Id.ToString()
                });
                rows.Cells.Add(idCell);

                TableCell nameCell = new TableCell();
                nameCell.Controls.Add(new Label()
                {
                    Text = types[i].Name.ToString()
                });
                rows.Cells.Add(nameCell);

                TableCell descCell = new TableCell();
                descCell.Controls.Add(new Label()
                {
                    Text = types[i].Description.ToString()
                });
                rows.Cells.Add(descCell);

                TableCell editBtnCell = new TableCell();
                Button editBtn = new Button()
                {
                    Text = "Update",
                    ID = (i + 1) + "E"
                };
                editBtn.Click += updateProd;
                editBtnCell.Controls.Add(editBtn);
                rows.Cells.Add(editBtnCell);

                TableCell delBtnCell = new TableCell();
                Button delBtn = new Button()
                {
                    Text = "Delete",
                    ID = (i + 1) + "D"
                };
                delBtn.Click += deleteProd;
                delBtnCell.Controls.Add(delBtn);
                rows.Cells.Add(delBtnCell);
            }
        }

        protected void updateProd(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                Response.Redirect("UpdateProdTypePage.aspx?id=" + int.Parse(((Label)productTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text) + "");
            }           
        }

        protected void deleteProd(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                int id = int.Parse(((Label)productTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text);

                Product products = db.Products.Where(a => a.ProductTypeID == id).FirstOrDefault();             
                if (products != null)
                {
                    errorMsg.Text = "Can't delete. This type used in products";
                }
                else
                {
                    TypeRepository.deleteProduct(id);

                    Response.Redirect("ProdTypePage.aspx");
                }  
            }
        }
    }
}