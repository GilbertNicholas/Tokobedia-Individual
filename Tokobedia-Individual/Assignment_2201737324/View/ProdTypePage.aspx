<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="ProdTypePage.aspx.cs" Inherits="Assignment_2201737324.View.ProdTypePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><asp:HyperLink ID="insertProduct" runat="server" NavigateUrl="InsertProdTypePage.aspx">Insert Product Type</asp:HyperLink></div>
    <div class="col-md-12">
        <div class="container">
            <center>
                <asp:Table ID="productTable" Class="table" CellSpacing="50" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Description</asp:TableHeaderCell>
                        <asp:TableHeaderCell ID="action" ColumnSpan="2">Action</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <div><asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label></div>
            </center>       
        </div>
    </div>
</asp:Content>
