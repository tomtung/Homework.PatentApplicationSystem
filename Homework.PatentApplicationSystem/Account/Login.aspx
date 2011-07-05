<%@ Page Title="Log In" Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Homework.PatentApplicationSystem.Account.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Styles/basic.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="Form1" runat="server">
    <div id="container">
    <div id="login">
        <asp:TextBox ID="txtUserName" runat="server" CssClass="username"/>
        <asp:TextBox ID="txtPWD" runat="server" CssClass="password" TextMode="Password"/>
        <button runat="server" onserverclick="btnOK_Click">登录</button>
    </div>
    </div>
    </form>
</body>
</html>