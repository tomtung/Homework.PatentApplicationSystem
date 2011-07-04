<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaseInfoUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.CaseInfoUserControl" %>

<asp:Table ID="tblCaseInfo" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblCaseName" Text="案件名称:" runat="server" />
        </asp:TableCell><asp:TableCell>
           <asp:Label ID="lblCaseNameInfo" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow CssClass="odd">
        <asp:TableCell>
            <asp:Label ID="lblCreateDate" Text="创建日期:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblCreateDateInfo" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow >
        <asp:TableCell>
            <asp:Label ID="lblDateLimit" Text="绝限日:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblDateLimitInfo" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow CssClass="odd">
        <asp:TableCell>
            <asp:Label ID="lblClientName" Text="客户名称:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:ListBox ID="lblClientNameInfo" Text="" runat="server" />
            
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow >
        <asp:TableCell>
            <asp:Label ID="lblClientID" Text="申请人证件号:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblClientIDInfo" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow CssClass="odd">
        <asp:TableCell>
            <asp:Label ID="lblDepartmentID" Text="机构代码" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblDepartmentIDInfo" runat="server" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow >
        <asp:TableCell>
            <asp:Label ID="lblInventorID" Text="发明人身份证号" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblInventorIDInfo" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>