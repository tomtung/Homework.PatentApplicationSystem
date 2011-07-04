<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaseFileUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.CaseFileUserControl" %>
<asp:ListView ID="listViewFiles" DataKeyNames="编号" runat="server" OnSelectedIndexChanged="listViewFiles_SelectedIndexChanged">
    <LayoutTemplate>
        <table>
            <thead>
                <tr>
                    <th scope="col">
                        案件名称
                    </th>
                    <th scope="col">
                        创建日期
                    </th>
                    <th scope="col">
                       案件绝限日
                    </th>
                    <th scope="col">
                        客户名
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
            
            <td>
                <%# Eval("名称") %>
            </td>
            <td>
                <%# Eval("创建时间") %>>
            </td>
            <td>
                <%# Eval("绝限日") %>>
            </td>
            <td>
                <%# Eval("客户号") %>>
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>

<asp:Label ID="lblTest" runat="server"></asp:Label>