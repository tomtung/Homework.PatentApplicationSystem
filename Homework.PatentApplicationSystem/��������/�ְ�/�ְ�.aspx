<%@ Page Title="" Language="C#" MasterPageFile="~/代理部主管/代理部主管Master.master" AutoEventWireup="true" CodeBehind="分案.aspx.cs" Inherits="Homework.PatentApplicationSystem.代理部主管.分案.分案" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="nav2">
        <user:Tab ID="TabStrip1" OnTabClick="TabStrip1_Click" runat="server" />
    </div>
    <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
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
                        <asp:ListBox ID="lBoxSponsor" DataSourceID=""  runat="server" />
                    </asp:TableCell></asp:TableRow></asp:Table><asp:MultiView ID="MultiVewDistributeCase" runat="server">
                <asp:View ID="ViewEmpty" runat="server">
                </asp:View>
                <asp:View ID="ViewContent" runat="server">
                    <asp:Table ID="tblDistributeCaseAttach" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblTranslator" Text="翻译" runat="server" />
                            </asp:TableCell><asp:TableCell>
                                <asp:ListBox ID="lBoxCaseWorker1" DataValueField="办案员列表" DataSourceID="" runat="server" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblFRev" Text="一校" runat="server" />
                            </asp:TableCell><asp:TableCell>
                                <asp:ListBox ID="lBoxCaseWorker2" DataValueField="办案员列表" DataSourceID="" runat="server" />
                            </asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblSRev" Text="二校" runat="server" />
                            </asp:TableCell><asp:TableCell>
                                <asp:ListBox ID="lBoxCaseWorker3" DataValueField="办案员列表" DataSourceID="" runat="server" />
                            </asp:TableCell></asp:TableRow></asp:Table>注意： 翻译、一校和二校必须选择不同办案员</asp:View></asp:MultiView></asp:View><asp:view id="viewcaseinfo" runat="server">
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
