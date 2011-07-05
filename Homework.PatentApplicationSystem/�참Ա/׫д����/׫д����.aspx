<%@ Page Title="" Language="C#" MasterPageFile="~/办案员/办案员Master.master" AutoEventWireup="true" CodeBehind="撰写五书.aspx.cs" Inherits="Homework.PatentApplicationSystem.办案员.撰写五书.撰写五书" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="nav2">
        <user:Tab ID="TabStrip" OnTabClick="TabStrip_Click" runat="server" />
    </div>
    <asp:MultiView ID="MultiView" ActiveViewIndex="0" runat="server">
        <asp:view id="viewcaseinfo" runat="server">
            <user:caseinfo id="caseInfo1" runat="server" />
        </asp:view>
        <asp:view id="viewrelatedfiles" runat="server">
            <user:file id="filecontrol1" runat="server"></user:file>
        </asp:view>
    </asp:MultiView>
    <div id="decide">
        <button runat="server" class="lbutton-blue" onserverclick="btnOK_Click">完成</button>
    </div>
</asp:Content>
