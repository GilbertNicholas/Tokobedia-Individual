<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="Assignment_2201737324.View.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2><p align="center">Profile Page</p></h2>
    </div>
    <center>
        <table cellpadding="5%">
            <tr>
                <td><label for="ProfileName"><pre>Name    : </pre></label></td>
                <td><asp:Label ID="ProfileName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><label for="ProfileEmail"><pre>Email   : </pre></label></td>
                <td><asp:Label ID="ProfileEmail" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><label for="ProfileGender"><pre>Gender  : </pre></label></td>
                <td><asp:Label ID="ProfileGender" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <center>
                    <td><asp:Button ID="btnUpdate" runat="server" Text="Update Profile" OnClick="btnUpdatePrfl"></asp:Button></td>
                    <td><asp:Button ID="btnChangePw" runat="server" Text="Change Password" OnClick="btnUpdatePw"></asp:Button></td>
                </center>
            </tr>
        </table>
    </center>
</asp:Content>
