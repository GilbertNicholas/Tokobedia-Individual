<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Assignment_2201737324.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <h2>
        <asp:Label ID="welcome" runat="server" Text=""></asp:Label>
    </h2>
    <div class="col-md-12">
        <div class="container">
            <asp:Table ID="productTable" Class="table" CellSpacing="50" runat="server">    
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Stock</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                </asp:TableHeaderRow>          
            </asp:Table>            
        </div>
    </div>
    </center>
</asp:Content>
