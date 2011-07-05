<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedBackUserControl.ascx.cs"
    Inherits="Homework.PatentApplicationSystem.UserControl.FeedBackUserControl" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>
<div id="main">
    <asp:ListView ID="DataListFeedBack" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <div class="feed">
                <span class="name">
                    <%# ((CaseMessage)Container.DataItem).SenderUsername %></span><span class="time"></span>
                <p>
                    <%# ((CaseMessage)Container.DataItem).Content %></p>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <div class="comment">
        <textarea id="commentText" runat="server"></textarea>
        <button id="Button1" type="button" class="mbutton" runat="server" onserverclick="btnFinish_Click">
            反馈</button>
    </div>
</div>
