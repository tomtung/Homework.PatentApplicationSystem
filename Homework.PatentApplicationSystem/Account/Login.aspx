<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Homework.PatentApplicationSystem.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <p>
        请输入用户名与密码, 如果没有请点击
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Register</asp:HyperLink>来创建帐户
    </p>
        <asp:Label ID="lblErrorMessage" Text="" Visible="false" runat="server"></asp:Label>
        <asp:Label ID="lblUserName" Text="用户名" runat="server">
        </asp:Label>
        &nbsp; 
        <asp:TextBox ID="txtUserName" runat="server" Width="128px"></asp:TextBox>
        <br />
        <asp:Label ID="lblPWD" Text="密码" runat="server">
        </asp:Label>
        &nbsp;
        <asp:TextBox ID="txtPWD" runat="server" Height="22px" Width="128px"></asp:TextBox>
        <br />
        &nbsp;
        <asp:Button ID="btnOK" Text="确定" runat="server" Height="26px" 
        onclick="btnOK_Click" />
   
</asp:Content>
