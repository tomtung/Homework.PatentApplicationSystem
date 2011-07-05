<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedBackUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.FeedBackUserControl" %>
<asp:DataList ID="DataListFeedBack" runat="server">
<ItemTemplate>
<tr>
    <td>
        <asp:Label ID="lblContent" runat="server"></asp:Label>
    </td>
</tr>
    <asp:Button ID="btnFinish" Text="完成"OnClick="btnFinish_Click" runat="server" /> 
    </ItemTemplate>

</asp:DataList>