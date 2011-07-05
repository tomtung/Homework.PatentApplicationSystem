﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaseFileUserControl.ascx.cs" Inherits="Homework.PatentApplicationSystem.UserControl.CaseFileUserControl" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>
<asp:ListView ID="listViewFiles" DataKeyNames="编号" runat="server"
OnSelectedIndexChanging="listViewFiles_SelectedIndexChanging" OnSelectedIndexChanged="listViewFiles_SelectedIndexChanged">
    <LayoutTemplate>
        <table >
            <thead>
                <tr >
                    <th scope="col">
                        案件名称
                    </th >
                    
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
                <%# ((Case)Container.DataItem).创建时间%>
            </td>
            <td>
                <%# ((Case)Container.DataItem).绝限日%>
            </td>
            <td>
                <%# ((Case)Container.DataItem).客户号 %>
            </td>
            <td>
                <asp:LinkButton ID="lBtnSelect" CommandName="Select" Text="选择" runat="server" />
            </td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
        <td>你的列表中没有等处理的案件!!!</td>
    </EmptyDataTemplate>
</asp:ListView>

<asp:Label ID="lblTest" runat="server" />

