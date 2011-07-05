<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework.PatentApplicationSystem.立案员.立案.Default" %>
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
                        <asp:Label ID="lblCaseNames" Text="案件名称:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tboxCaseName" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow CssClass="odd">
                    <asp:TableCell>
                        <asp:Label ID="lblCaseType" Text="案件类型:" runat="server"></asp:Label>
                    </asp:TableCell><asp:TableCell>
                        <asp:ListBox ID="lBoxCaseType" runat="server"></asp:ListBox>
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblCreateDate" Text="创建日期:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tboxCreateDate" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow CssClass="odd">
                    <asp:TableCell>
                        <asp:Label ID="lblDateLimit" Text="绝限日:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:Label ID="lblDateLimitInfo" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblClientName" Text="客户名称:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:ListBox ID="lBoxClientName" DataTextField="已存档客户" DataValueField="clientName"
                            DataSourceID="" runat="server" />
                        &nbsp;<asp:Button ID="btnAddClient" CssClass="mbutton" Text="+ 添加" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow CssClass="odd">
                    <asp:TableCell>
                        <asp:Label ID="lblClientID" Text="申请人证件号/机构代码:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tBoxClientID" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblInventorID" Text="发明人身份证号" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:TextBox ID="tBoxInventorID" runat="server" />
                    </asp:TableCell></asp:TableRow></asp:Table><br /></asp:View><asp:View>
            <user:File ID="relatedFiles" runat="server" />
        </asp:View>
        <asp:View>
            <user:CaseMessageUserControl ID="CaseMessageUserControl1" runat="server" />
        </asp:View>
        </asp:MultiView><div id="decide">
        <asp:Button ID="btnOK" Text="完成" CssClass="lbutton_blue" OnClick="btnOK_Click" runat="server" />
    </div>
			
</asp:Content>
