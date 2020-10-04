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
    public partial class ProductPage : System.Web.UI.Page
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
                    insertProduct.Visible = false;
                    action.Visible = false;
                }
            }
            if (Session["member"] != null)
            {
                insertProduct.Visible = false;
                action.Visible = false;
            }

            List<Product> products = ProductRepository.getProducts();

            for (int i = 0; i < products.Count; i++)
            {
                TableRow rows = new TableRow();
                productTable.Controls.Add(rows);

                TableCell idCell = new TableCell();
                idCell.Controls.Add(new Label()
                {
                    Text = products[i].Id.ToString()
                });
                rows.Cells.Add(idCell);

                TableCell typeCell = new TableCell();
                int typeId = products[i].ProductTypeID;
                ProductType types = db.ProductTypes.Where(x => x.Id == typeId).FirstOrDefault();
                typeCell.Controls.Add(new Label()
                {
                    Text = types.Name.ToString()
                });
                rows.Cells.Add(typeCell);

                TableCell nameCell = new TableCell();
                nameCell.Controls.Add(new Label()
                {
                    Text = products[i].Name.ToString()
                });
                rows.Cells.Add(nameCell);

                TableCell stockCell = new TableCell();
                stockCell.Controls.Add(new Label()
                {
                    Text = products[i].Stock.ToString()
                });
                rows.Cells.Add(stockCell);

                TableCell priceCell = new TableCell();
                priceCell.Controls.Add(new Label()
                {
                    Text = products[i].Price.ToString()
                });
                rows.Cells.Add(priceCell);

                if (Session["admin"] != null)
                {
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
        }
        
        protected void updateProd(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if(int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                Response.Redirect("UpdateProdPage.aspx?id=" + int.Parse(((Label)productTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text) + "");    
            }            
        }

        protected void deleteProd(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if(int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                int id = int.Parse(((Label)productTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text);

                TransactionDetail details = db.TransactionDetails.Where(a => a.ProductId == id).FirstOrDefault();
                if(details !=null)
                {
                    errorMsg.Text = "Can't delete. This product used in transaction detail";
                }
                else
                {
                    ProductRepository.deleteProduct(id);

                    Response.Redirect("ProductPage.aspx");
                }    
            }
        }
    }
}