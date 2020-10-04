<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="InsertProdPage.aspx.cs" Inherits="Assignment_2201737324.View.InsertProdPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2><p align="center">Insert Product Page</p></h2>
    </div>
    <center>
        <table cellpadding="5%">
            <tr>
                <td><label for="nameProd"><pre>Name    : </pre></label></td>
                <td><asp:TextBox ID="nameProd" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="nameProd" runat="server" ErrorMessage="Product name must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td><label for="stockProd"><pre>Stock   : </pre></label></td>
                <td><asp:TextBox ID="stockProd" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="stockProd" runat="server" ErrorMessage="Product stock must be filled" ForeColor="Red"></asp:RequiredFieldValidator>                
            </tr>
            <tr>
                <td><label for="priceProd"><pre>Price   : </pre></label></td>
                <td><asp:TextBox ID="priceProd" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="priceProd" runat="server" ErrorMessage="Product price must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td><label for="typeIdProd"><pre>Type Name    : </pre></label></td>
                <td><asp:TextBox ID="typeIdProd" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ControlToValidate="typeIdProd" runat="server" ErrorMessage="Product type must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <asp:Button ID="btnInsert" runat="server" TabIndex="5" Text="Insert" OnClick="insertProduct"/>
                    </center>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
