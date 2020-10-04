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
    public partial class UserPage : System.Web.UI.Page
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

            List<User> user = UserRepository.getUser();

            for (int i = 0; i < user.Count; i++)
            {

                TableRow rows = new TableRow();
                userTable.Controls.Add(rows);

                TableCell idCell = new TableCell();
                idCell.Controls.Add(new Label()
                {
                    Text = user[i].Id.ToString()
                });
                rows.Cells.Add(idCell);

                TableCell roleCell = new TableCell();
                int roleId = user[i].RoleId;
                string role;
                if (roleId == 1)
                {
                    role = "Admin";
                }
                else
                {
                    role = "Member";
                }
                roleCell.Controls.Add(new Label()
                {
                    Text = role.ToString()
                });
                rows.Cells.Add(roleCell);

                TableCell editRoleCell = new TableCell();
                if (user[i].Id != ((User)Session["admin"]).Id)
                {
                    Button editRole = new Button()
                    {
                        Text = "Change",
                        ID = (i + 1) + "R",
                        ForeColor = System.Drawing.Color.Red
                    };
                    editRole.Click += changeRole;
                    editRoleCell.Controls.Add(editRole);
                }
                rows.Cells.Add(editRoleCell);

                TableCell nameCell = new TableCell();
                nameCell.Controls.Add(new Label()
                {
                    Text = user[i].Name.ToString()
                });
                rows.Cells.Add(nameCell);

                TableCell emailCell = new TableCell();
                emailCell.Controls.Add(new Label()
                {
                    Text = user[i].Email.ToString()
                });
                rows.Cells.Add(emailCell);

                TableCell statusCell = new TableCell();
                int statusId = user[i].Status;
                string status;
                if (statusId == 1)
                {
                    status = "Active";
                }
                else
                {
                    status = "Blocked";
                }
                statusCell.Controls.Add(new Label()
                {
                    Text = status.ToString()
                });
                rows.Cells.Add(statusCell);

                TableCell editStatusCell = new TableCell();
                if (user[i].Id != ((User)Session["admin"]).Id)
                {   
                    Button editStatus = new Button()
                    {
                        Text = "Change",
                        ID = (i + 1) + "S",
                        ForeColor = System.Drawing.Color.Red
                    };
                    editStatus.Click += changeStatus;
                    editStatusCell.Controls.Add(editStatus);
                }
                rows.Cells.Add(editStatusCell);
            }
        }

        protected void changeRole(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                int Id = int.Parse(((Label)userTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text);
                string roleName = ((Label)userTable.Rows[selectedRowIndex].Cells[1].Controls[0]).Text;

                Role roles = db.Roles.Where(a => a.Name == roleName).FirstOrDefault();

                int role = roles.Id;

                if (role == 1) role = 2;
                else if (role == 2) role = 1; 

                UserRepository.changeRole(Id, role);

                Response.Redirect("UserPage.aspx");
            }
        }

        protected void changeStatus(object sender, EventArgs e)
        {
            Button currBtn = (Button)sender;
            int selectedRowIndex = 0;
            if (int.TryParse(currBtn.ID.Substring(0, currBtn.ID.Length - 1), out selectedRowIndex))
            {
                int Id = int.Parse(((Label)userTable.Rows[selectedRowIndex].Cells[0].Controls[0]).Text);
                string statusName = ((Label)userTable.Rows[selectedRowIndex].Cells[5].Controls[0]).Text;

                int status = 0;

                if (statusName.Equals("Active")) status = 2;
                else if (statusName.Equals("Blocked")) status = 1;

                UserRepository.changeStatus(Id, status);

                Response.Redirect("UserPage.aspx");
            }
        }
    }
}