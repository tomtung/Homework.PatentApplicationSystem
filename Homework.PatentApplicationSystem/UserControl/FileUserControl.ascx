﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUserControl.ascx.cs"
 Inherits="Homework.PatentApplicationSystem.UserControl.FileUserControl" %>
 <%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>

<asp:FileUpload ID="FileUpload1" Visible="false" runat="server" /> &nbsp; <asp:Button ID="btnUpload" Text="上传" OnClick="btnUpload_Click"  Visible="false" runat="server" />

 
<asp:ListView ID="listViewFiles" DataKeyNames="FileName" runat="server" OnSelectedIndexChanged="listViewFiles_SelectedIndexChanged"
 OnSelectedIndexChanging="listViewFiles_SelectedIndexChanging">
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
    <ItemTemplate>s
        <tr>
            <td class="checkbox">
                <asp:CheckBox ID="cBox1" Checked="false" runat="server" />
            </td>
            <td>
                <%# ((CaseDoc)(Container.DataItem)).FileName  %>
            </td>
              <td>
                <%# ((CaseDoc)(Container.DataItem)).UploadUserName %>>
            </td>
            <td>
                <%# ((CaseDoc)(Container.DataItem)).UploadDateTime %>>
            </td>
   
            <td>
                 <asp:LinkButton ID="lbtnDownload" Text="下载" CommandName="Select" OnClick = "lbtnDownload_Click" runat="server"></asp:LinkButton>
                 
            </td>

        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
    <td>你的列表中没有等处理的案件!!!</td>
    </EmptyDataTemplate>
</asp:ListView>
<asp:Button ID="btnAdd" Text="+ 添加" runat="server" onclick="btnAdd_Click" /> &nbsp; 




