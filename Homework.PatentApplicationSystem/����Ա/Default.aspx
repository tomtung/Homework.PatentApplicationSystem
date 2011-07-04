<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework.PatentApplicationSystem.立案员.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="nav2">
        <user:Tab ID="TabStrip1" OnTabClick="TabStrip1_Click" runat="server" />
    </div>
    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <asp:View ID="ViewCaseInfo" runat="server">
            <asp:Table ID="tblCaseInfo" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" Text="案件名称:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tboxCaseName" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" Text="创建日期:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tboxCreateDate" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label3" Text="绝限日:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:Label ID="lblDateLimit" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label4" Text="客户名称:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:ListBox ID="lBoxClientName" DataTextField="已存档客户" DataValueField="clientName"
                            DataSourceID="" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:Button ID="btnAddClient" Text="添加客户" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label5" Text="申请人证件号:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tBoxClientID" Text="/" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label6" Text="机构代码" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tBoxDepartmentID" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label7" Text="发明人身份证号" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tBoxInventorID" runat="server" />
                    </asp:TableCell></asp:TableRow></asp:Table><br /><asp:Button ID="Button1" Text="完成" runat="server" />
        </asp:View>
        <asp:View ID="ViewRelatedFiles" runat="server">
            <asp:Table ID="tblRelatedFiles" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:GridView ID="gvRelatedFile" DataSourceID="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="btnAdd" Text="添加" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:Button ID="btnRemove" Text="删除" runat="server" />
                    </asp:TableCell></asp:TableRow></asp:Table><asp:Button ID="btnOK" Text="通过" runat="server" />
            <asp:Button ID="btnCancel" Text="不通过" runat="server" />
        </asp:View>
    </asp:MultiView>
</asp:Content>