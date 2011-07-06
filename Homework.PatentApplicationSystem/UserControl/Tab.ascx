<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tab.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.Tab" %>
<ul>
    <asp:ListView ID="lstViewTabStrip" OnSelectedIndexChanged="lstViewTabStrip_SelectedIndexChanged" OnSelectedIndexChanging="lstViewTabStrip_SelectedIndexChanging" runat="server">
        <ItemTemplate>
            <li>
                <asp:LinkButton ID="lnkTab" Text="<%# Container.DataItem %>" CommandName="Select" runat="server"></asp:LinkButton>
            </li>
        </ItemTemplate>
    </asp:ListView>
 
</ul>
