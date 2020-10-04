<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="InsertProdTypePage.aspx.cs" Inherits="Assignment_2201737324.View.InsertProdTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2><p align="center">Insert Product Type Page</p></h2>
    </div>
    <center>
        <table cellpadding="5%">
            <tr>
                <td><label for="nameType"><pre>Type Name    : </pre></label></td>
                <td><asp:TextBox ID="nameType" runat="server"></asp:TextBox></td>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate ="nameType" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{5,}$" runat="server" ErrorMessage="Minimum 5 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="nameType" runat="server" ErrorMessage="Type name must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td><label for="desc"><pre>Description   : </pre></label></td>
                <td><asp:TextBox ID="desc" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ControlToValidate="desc" runat="server" ErrorMessage="Description must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <center>
                    <td colspan="2">
                        <td><asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                    </td>
                </center>
            </tr>
            <tr>
                <center>
                    <td colspan="2">
                        <td><asp:Label ID="successMsg" runat="server" Text="" ForeColor="Green"></asp:Label></td>
                    </td>
                </center>
            </tr>
            <tr>
                <td colspan ="2">
                    <center>
                        <asp:Button ID="btnInsert" runat="server" TabIndex="5" Text="Insert" OnClick="insertType"/>
                    </center>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
