<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="案件信息.aspx.cs" Inherits="Homework.PatentApplicationSystem.立案员.案件信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="tblCaseInfo" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="案件名称:" runat="server" />
                
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="tboxCaseName" Text="" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="创建日期:" runat="server" />
                
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="tboxCreateDate" Text="" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label  Text="绝限日:" runat="server" />
                
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblDateLimit" Text="" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="客户名称:" runat="server" />
                
            </asp:TableCell><asp:TableCell>
                <asp:ListBox ID="lBoxClientName" DataTextField="已存档客户" DataValueField="clientName" DataSourceID="" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Button ID="btnAddClient" Text="添加客户" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label  Text="申请人证件号:" runat="server" />
                
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="tBoxClientID" Text="/" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="机构代码" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="tBoxDepartmentID" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label Text="发明人身份证号" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="tBoxInventorID" runat="server" />
            </asp:TableCell></asp:TableRow></asp:Table><br />
    <asp:Button ID = "btnOK" Text="完成" runat="server" />
</asp:Content>
