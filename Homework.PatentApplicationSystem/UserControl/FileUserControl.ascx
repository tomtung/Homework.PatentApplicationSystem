<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUserControl.ascx.cs"
    Inherits="Homework.PatentApplicationSystem.UserControl.FileUserControl" %>
<asp:ListView ID="listViewFiles" DataKeyNames="案件编号" runat="server" OnSelectedIndexChanged="listViewFiles_SelectedIndexChanged">
    <LayoutTemplate>
        <table>
            <thead>
                <tr>
                    <th scope="col">
                    </th>
                    <th scope="col">
                        文件名
                    </th>
                    <th scope="col">
                        创建人
                    </th>
                    <th scope="col">
                        创建日期
                    </th>
                    <th scope="col">
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </tbody>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td class="checkbox">
                <asp:CheckBox ID="cBox1" runat="server" />
            </td>
            <td>
                <%# Eval("FileName") %>
            </td>
            <td>
                <%# Eval("UploadDateTime") %>>
            </td>
            <td>
                <%# Eval("UploadUserName") %>>
            </td>
            <td>
                 <asp:LinkButton ID="lBtnDownload" Text="下载" OnClick="lbtnDownload_Click"  runat="server" />
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>
<asp:Button ID="btnAdd" Text="+ 添加" runat="server" /> &nbsp; 
<asp:Button ID="btnDelete" text="- 删除" runat="server" />



