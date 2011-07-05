<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaseFileUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.CaseFileUserControl" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>
<asp:ListView ID="listViewFiles" DataKeyNames="编号" runat="server" OnSelectedIndexChanged="listViewFiles_SelectedIndexChanged" OnSelectedIndexChanging="listViewFiles_SelectedIndexChanging"
 >
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
            <td>
                <%# ((Case)Container.DataItem).名称 %>
            </td>
            <td>
                <%# ((Case)Container.DataItem).创建时间%>>
            </td>
            <td>
                <%# ((Case)Container.DataItem).绝限日%>>
            </td>
            <td>
                <%# ((Case)Container.DataItem).客户号 %>>
            </td>
            <td>
                <asp:LinkButton ID="lBtnSelect" CommandName="Select" Text="选择" OnClick="lbtnSelect_Click"  runat="server" />
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>

<asp:Label ID="lblTest" runat="server" />

