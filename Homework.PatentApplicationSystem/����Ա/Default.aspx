<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework.PatentApplicationSystem.立案员.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="nav2">
        <user:Tab ID="TabStrip1" OnTabClick="TabStrip1_Click" runat="server" />
    </div>
    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <asp:View ID="ViewCaseInfo" runat="server">
            <user:SetupCaseCaseInfo ID="scCaseInfo" runat="server" />
        </asp:View> 
        
    </asp:MultiView>
</asp:Content>