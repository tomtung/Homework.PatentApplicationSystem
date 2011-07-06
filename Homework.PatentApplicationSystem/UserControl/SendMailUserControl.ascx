<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendMailUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.SendMailUserControl" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

  <table style="width: 100%" align="center">
        <tr>
            <td style="width: 50px">
                收件人
                <asp:Label ID="testlabel" Text="test" runat="server"></asp:Label>
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtFrom" runat="server" Width="400px" Style="margin-left: 1px"></asp:TextBox>
                <asp:TextBox ID="txtTo" runat="server" Width="400px" Style="margin-left: 1px"></asp:TextBox>

            </td>
            <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTo"
                    Display="Dynamic" ErrorMessage="1"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTo"
                    Display="Dynamic" ErrorMessage="1"></asp:RequiredFieldValidator>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTo"
                    Display="Dynamic" ErrorMessage="2" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 50px">
                主题
            </td>
            <td style="width: 300px">
                <asp:TextBox ID="txtSubject" runat="server" Height="50px" MaxLength="200" TextMode="MultiLine"
                    Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 652px">
                &nbsp;
            </td>
            <td style="width: 310px">
                &nbsp;
            </td>
            <td style="width: 385px">
                &nbsp;
            </td>
        </tr>
    </table>
    <div style="width: 100%;">
        <FTB:FreeTextBox ID="txtBody" Width="100%"
	
            ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat;SymbolsMenu,InsertRule,InsertDate,InsertTime;InsertTable|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo" 
            runat="server" ButtonSet="OfficeMac"/>
        <asp:Button ID="btnOK" runat="server" Text="发送" style="float:right" 
            onclick="btnOK_Click"/>
    </div>