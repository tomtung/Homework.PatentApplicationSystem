<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedBackUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.FeedBackUserControl" %>
<asp:DataList ID="DataListFeedBack" runat="server">
<ItemTemplate>
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
    <asp:TextBox ID="tBoxContent" ReadOnly="true" runat="server"></asp:TextBox>
    <asp:TextBox ID="tBoxInput" runat="server"></asp:TextBox>
    <asp:Button ID="btnFinish" Text="完成" OnClick="btnFinish_Click" runat="server" />
</ItemTemplate>
</asp:DataList>