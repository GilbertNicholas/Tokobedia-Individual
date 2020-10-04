<%@ Page Title="" Language="C#" MasterPageFile="~/View/Home.Master" AutoEventWireup="true" CodeBehind="ChangePwPage.aspx.cs" Inherits="Assignment_2201737324.View.ChangePwPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2><p align="center">Change Password Page</p></h2>
    </div>
    <center>
        <table cellpadding="5%">
            <tr>
                <td><label for="OldPassword"><pre>Old Password    : </pre></label></td>
                <td><asp:TextBox ID="OldPassword" runat="server" type="password" AutoCompleteType="Disabled"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="OldPassword" runat="server" ErrorMessage="Old Password must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td><label for="NewPassword"><pre>New Password   : </pre></label></td>
                <td><asp:TextBox ID="NewPassword" runat="server" type="password" AutoCompleteType="Disabled"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="NewPassword" runat="server" ErrorMessage="New Password must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "NewPassword" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{5,}$" runat="server" ErrorMessage="Minimum 5 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
            </tr>
            <tr>
                <td><label for="ConfirmPassword"><pre>Confirm Password  : </pre></label></td>
                <td><asp:TextBox ID="ConfirmPassword" runat="server" type="password" AutoCompleteType="Disabled"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ConfirmPassword" runat="server" ErrorMessage="Confirm Password must be filled" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmPassword" operator="Equal" type="String" ErrorMessage="Password doesn't match" ForeColor="Red"></asp:CompareValidator>
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
                        <asp:Button ID="btnSubmit" runat="server" TabIndex="5" Text="Submit" OnClick="submitChange"/>
                    </center>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
