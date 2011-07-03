<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="相关文件.aspx.cs" Inherits="Homework.PatentApplicationSystem.立案员.相关信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblRelatedFiles" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="gvRelatedFile"  DataSourceID="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button ID="btnAdd" Text="添加" runat="server" />

        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="btnRemove" Text="删除" runat="server" />
        </asp:TableCell>
    </asp:TableRow>

</asp:Table>

<asp:Button ID="btnOK" Text="通过" runat="server" />
<asp:Button ID="btnCancel" Text="不通过"  runat="server" />
</asp:Content>
