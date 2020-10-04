<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="UpdatePrflPage.aspx.cs" Inherits="Assignment_2201737324.View.UpdatePrflPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2><p align="center">Update Profile Page</p></h2>
    </div>
    <center>
        <table cellpadding="5%">
            <tr>
                <td><label for="email"><pre>Email    : </pre></label></td>
                <td><asp:TextBox ID="email" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="email" runat="server" ErrorMessage="New Email must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td><label for="name"><pre>Name   : </pre></label></td>
                <td><asp:TextBox ID="name" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="name" runat="server" ErrorMessage="New Name must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td><label for="ddgender"><pre>Gender : </pre></label></td>
                <td>
                    <asp:RadioButtonList ID="radioGender" runat="server" >
                        <asp:listitem Value="Male">Male</asp:listitem>
                        <asp:listitem Value="Female">Female</asp:listitem>
                     </asp:RadioButtonList>
                </td>
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
                        <asp:Button ID="btnSubmit" runat="server" TabIndex="5" Text="Update" OnClick="submitUpdate"/>
                    </center>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
