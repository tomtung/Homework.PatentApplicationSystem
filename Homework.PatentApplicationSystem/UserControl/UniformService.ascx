<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UniformService.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.UniformService" %>
 <div id="nav2">
        <user:Tab ID="TabStrip1" OnTabClick="TabStrip1_Click" runat="server" />
</div>ndex="0" runat="server">
<asp:View ID="ViewCaseInfo" runat="server">
            <user:CaseInfo ID="caseInfo1" 
<asp:MultiView ID="MultiView1" ActiveViewIrunat="server" />
        </asp:View>
        <asp:View ID="ViewRelatedFiles" runat="server">
            <user:File ID="fileControl1" runat="server"></user:file>
        </asp:View>
        <asp:View ID="ViewFeedBack" runat="server">
            <user:FeedBack ID="FeedBack1" runat="server" />
        </asp:View>
</asp:MultiView>