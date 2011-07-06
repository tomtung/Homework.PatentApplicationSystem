<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="分案.aspx.cs" Inherits="Homework.PatentApplicationSystem.代理部主管.分案.分案" %>
<%@MasterType TypeName="Homework.PatentApplicationSystem.SiteMaster" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="nav2">
        <user:Tab ID="TabStrip" OnTabClick="TabStrip_Click" runat="server" />
    </div>
    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <asp:view id="viewcaseinfo" runat="server">
            <user:caseinfo id="caseInfo1" runat="server" />
        </asp:view>
        <asp:View ID="ViewDistributeCase" runat="server">
            <asp:Table ID="tblDistributeCaseMain" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblCaseType" Text="案件种类:" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:Label ID="lblCaseTypeInfo" Text="" runat="server" />
                    </asp:TableCell></asp:TableRow><asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblSponsor" Text="主办人" runat="server" />
                    </asp:TableCell><asp:TableCell>
                        <asp:ListBox ID="lBoxSponsor" runat="server" />
                    </asp:TableCell></asp:TableRow></asp:Table><asp:MultiView ID="MultiVewDistributeCase" runat="server">
                <asp:View ID="ViewEmpty" runat="server">
                </asp:View>
                <asp:View ID="ViewContent" runat="server">
                    <asp:Table ID="tblDistributeCaseAttach" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblTranslator" Text="翻译" runat="server" />
                            </asp:TableCell><asp:TableCell>
                                <asp:ListBox ID="lBoxCaseWorker1" runat="server" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblFRev" Text="一校" runat="server" />
                            </asp:TableCell><asp:TableCell>
                                <asp:ListBox ID="lBoxCaseWorker2" runat="server" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblSRev" Text="二校" runat="server" />
                            </asp:TableCell><asp:TableCell>
                                <asp:ListBox ID="lBoxCaseWorker3" runat="server" />
                            </asp:TableCell></asp:TableRow></asp:Table>注意： 翻译、一校和二校必须选择不同办案员</asp:View></asp:MultiView></asp:View>
        <asp:view id="viewrelatedfiles" runat="server">
            <user:file id="filecontrol1" runat="server"></user:file>
        </asp:view>
        <asp:View runat="server">
            <user:FeedBack runat="server"/>
        </asp:View>
    </asp:MultiView>
    <div id="decide">
    <button runat="server" class="lbutton-blue" onserverclick="btnOK_Click">完成</button>
    </div>
</asp:Content>
