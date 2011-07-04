<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetupCaseCaseInfoUserControl.ascx.cs"
    Inherits="Homework.PatentApplicationSystem.UserControl.SetupCaseCaseInfoUserControl" %>
<asp:Table ID="tblCaseInfo" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label1" Text="案件名称:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="tboxCaseName" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="odd">
        <asp:TableCell>
                <asp:Label Text="案件类型:" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:ListBox ID="lBoxCaseType" runat="server"></asp:ListBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label2" Text="创建日期:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="tboxCreateDate" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="odd">
        <asp:TableCell>
            <asp:Label ID="Label3" Text="绝限日:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblDateLimit" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label4" Text="客户名称:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:ListBox ID="lBoxClientName" DataTextField="已存档客户" DataValueField="clientName"
                DataSourceID="" runat="server" />
            &nbsp;<asp:Button ID="btnAddClient" CssClass="mbutton" Text="+ 添加" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="odd">
        <asp:TableCell>
            <asp:Label ID="Label5" Text="申请人证件号:" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="tBoxClientID" Text="" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label6" Text="机构代码" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="tBoxDepartmentID" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="odd">
        <asp:TableCell>
            <asp:Label ID="Label7" Text="发明人身份证号" runat="server" />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="tBoxInventorID" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<div id="decide">
    <asp:Button ID="btnOK" Text="完成" CssClass="lbutton_blue" OnClick="btnOK_Click" runat="server" />
</div>
