﻿<%@ Page Title="" Language="C#" MasterPageFile="~/质检员/质检员Master.master" AutoEventWireup="true" CodeBehind="流程部质检.aspx.cs" Inherits="Homework.PatentApplicationSystem.质检员.流程部质检.流程部质检" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="nav2">
        <user:Tab ID="TabStrip1" OnTabClick="TabStrip1_Click" runat="server" />
    </div>
    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        
        <asp:view id="viewcaseinfo" runat="server">
            <user:caseinfo id="caseInfo1" runat="server" />
        </asp:view>
        <asp:view id="viewrelatedfiles" runat="server">
            <user:file id="filecontrol1" runat="server"></user:file>
        </asp:view>
<%--        <asp:View ID="ViewFeedBack" runat="server">
            <user::FeedBack ID="FeedBack1" runat="server" />
        </asp:View>--%>
    </asp:MultiView>
    
    <asp:Button ID="btnOK" Text="完成" OnClick="btnOK_Click" runat="server" />

</asp:Content>
