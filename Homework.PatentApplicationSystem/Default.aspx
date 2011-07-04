<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Homework.PatentApplicationSystem._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label  ID="lblUserName" Text="" runat="server"></asp:Label>, 欢迎使用专利业务系统
    </h2>
    <p>
        您有<asp:Label ID="lblWaitingCases" Text= "0" runat="server"></asp:Label>封待审稿件
        <br />
        您有<asp:Label ID="lblNewMail" Text= "0" runat="server"></asp:Label>封待阅邮件
        <br />
        
        
    </p>
    
        
</asp:Content>
