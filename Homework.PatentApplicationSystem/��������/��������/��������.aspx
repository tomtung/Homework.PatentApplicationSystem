<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="代理部内审.aspx.cs" Inherits="Homework.PatentApplicationSystem.代理部主管.代理部内审.代理部内审" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div id="nav2">
        <user:Tab ID="TabStrip1" OnTabClick="TabStrip1_Click" runat="server" />
</div>
    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
<asp:View ID="ViewCaseInfo" runat="server">
          <user:CaseInfo ID="caseInfo1" runat="server" />
        </asp:View>
        <asp:View ID="ViewRelatedFiles" runat="server">
            <user:File ID="fileControl1" runat="server"></user:file>
        </asp:View>
        <asp:View ID="ViewFeedBack" runat="server">
            <user:FeedBack ID="FeedBack1" runat="server" />
        </asp:View>
</asp:MultiView>
</asp:Content>
