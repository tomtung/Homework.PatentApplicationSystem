<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaseMessageUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.CaseMessageUserControl" %>
<asp:DataList ID="DataListCaseMessage" runat="server">
    <ItemTemplate>
        <%#Eval("SenderUsername") %>
        <br />
        <%#Eval("Content") %>

    </ItemTemplate>
</asp:DataList>

<asp:TextBox ID="tBoxFeedBack" runat="server" /> <asp:Button ID="btnSend" OnClick="btnSend_Click" runat="server" />