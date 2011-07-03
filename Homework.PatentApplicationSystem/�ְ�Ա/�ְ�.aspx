<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="分案.aspx.cs" Inherits="Homework.PatentApplicationSystem.分案员.分案员" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="tblDistributeCase" runat="server" >
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblCaseType" Text="案件种类:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:ListBox ID="lBoxCaseType" DataSourceID="" runat="server" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblSponsor" Text="主办人" runat="server" />

        </asp:TableCell><asp:TableCell>
            <asp:ListBox ID="lBoxSponsor" DataSourceID="" runat="server" />
        </asp:TableCell></asp:TableRow><%--   <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblTranslator" Text="翻译" runat="server" />

        </asp:TableCell>
        <asp:TableCell>
            <asp:ListBox ID="lBoxCaseWorker1" DataValueField="办案员列表" DataSourceID="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell>
            <asp:Label ID="lblFRev" Text="一校" runat="server" />

        </asp:TableCell>
        <asp:TableCell>
            <asp:ListBox ID="lBoxCaseWorker2" DataValueField="办案员列表" DataSourceID="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
      <asp:TableRow>
                <asp:TableCell>
            <asp:Label ID="lblSRev" Text="二校" runat="server" />

        </asp:TableCell>
        <asp:TableCell>
            <asp:ListBox ID="lBoxCaseWorker3" DataValueField="办案员列表" DataSourceID="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>--%></asp:Table><asp:Button ID="btnOK" Text="完成" runat="server" />

</asp:Content>
