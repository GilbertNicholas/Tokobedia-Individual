<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Assignment_2201737324.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RegisterPage</title>
</head>
<body>
    <div>
        <h2><p align="center">Register Page</p></h2>
    </div>
    <form id="form1" runat="server">
        <center>
            <table cellpadding="5%">
                <tr>
                    <td><label for="email"><pre>Email    : </pre></label></td>
                    <td><asp:Textbox ID="email" runat="server" TabIndex="1" Width="200px"></asp:Textbox></td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email must be filled" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td><label for="name"><pre>Name    : </pre></label></td>
                    <td><asp:Textbox ID="name" runat="server" TabIndex="2" Width="200px"></asp:Textbox></td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name must be filled" ControlToValidate="name" ForeColor="Red"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td><label for="password"><pre>Password : </pre></label></td>
                    <td><asp:Textbox Type="password" ID="password" runat="server" TabIndex="3" Width="200px"></asp:Textbox></td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password must be filled" ControlToValidate="password" ForeColor="Red"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td><label for="cpassword"><pre>Confirm Password : </pre></label></td>
                    <td><asp:Textbox Type="password" ID="cpassword" runat="server" TabIndex="4" Width="200px"></asp:Textbox></td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Confirm Password must be filled" ControlToValidate="cpassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="password" ControlToValidate="cpassword" operator="Equal" type="String" ErrorMessage="Password doesn't match" ForeColor="Red"></asp:CompareValidator>
                </tr>
                <tr>
                    <td><label for="ddgender"><pre>Gender : </pre></label></td>
                    <td>
                        <asp:RadioButtonList ID="radioGender" runat="server" >
                            <asp:listitem Selected="True" Value="Male">Male</asp:listitem>
                            <asp:listitem Value="Female">Female</asp:listitem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <center>
                            <asp:Label ID="errorMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <center>
                            <asp:Button ID="btnLogin" runat="server" TabIndex="5" Text="Register" OnClick="registerUser"/>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top:10%;">
                        <center>
                            Already have an account? Login <asp:HyperLink ID="linkLogin" runat="server" NavigateUrl="~/View/LoginPage.aspx" TabIndex="6">here.</asp:HyperLink>
                        </center>
                    </td>
                </tr>

            </table>
        </center>
    </form>
</body>
</html>

