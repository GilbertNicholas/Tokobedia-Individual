<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Assignment_2201737324.View.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
        <div class="container">
            <center>
            <asp:Table ID="userTable" Class="table" CellSpacing="50" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Role</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Change Role</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Change Status</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            </center>
        </div>
    </div>
</asp:Content>
