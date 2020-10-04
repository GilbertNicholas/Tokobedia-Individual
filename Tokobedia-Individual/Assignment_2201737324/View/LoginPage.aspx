<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Assignment_2201737324.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoginPage</title>
</head>
<body>
    <div>
        <h2><p align="center">Login Page</p></h2>
    </div>
    <form id="form1" runat="server">
        <center>
            <table cellpadding="5%">
                <tr>
                    <td><label for="email"><pre>Email    : </pre></label></td>
                    <td><asp:Textbox ID="email" runat="server" TabIndex="1" Width="200px"></asp:Textbox></td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email must be filled" ControltoValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td><label for="password"><pre>Password : </pre></label></td>
                    <td><asp:Textbox Type="password" ID="password" runat="server" TabIndex="2" Width="200px"></asp:Textbox></td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password must be filled" ControltoValidate="password" ForeColor="Red"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td colspan ="2">
                        <center>
                            <asp:CheckBox ID="rememberMe" runat="server" TabIndex="3" Text="Remember Me"/>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <center>
                            <asp:Button ID="btnLogin" runat="server" TabIndex="4" Text="Login" OnClick="loginUser"/>
                        </center>
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
                    <td colspan="2" style="padding-top:10%;">
                        <center>
                            New guest? Register <asp:HyperLink ID="linkRegister" runat="server" NavigateUrl="~/View/RegisterPage.aspx" TabIndex="5">here.</asp:HyperLink>
                        </center>
                    </td>
                </tr>

            </table>
        </center>
    </form>
</body>
</html>

