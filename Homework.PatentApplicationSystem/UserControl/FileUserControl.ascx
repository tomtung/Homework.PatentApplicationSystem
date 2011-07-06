<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUserControl.ascx.cs"
 Inherits="Homework.PatentApplicationSystem.UserControl.FileUserControl" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>

<Upload:ProgressBar ID="ProgressBar" runat='server' />
<br />
<Upload:InputFile ID="InputFile" Visible="false"  runat="server" />
<asp:Button ID="btnUpload" Text="上传" OnClick="btnUpload_Click"  Visible="false" runat="server" />
<br />
<asp:Label ID="lblErrorMessage" Visible="false" runat="server" />
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
    <ItemTemplate>
        <tr>
            <td class="checkbox">
                <asp:CheckBox ID="cBox1" Checked="false" runat="server" />
            </td>
            <td>
                <%# ((CaseDoc)(Container.DataItem)).FileName  %>
            </td>
              <td>
                <%# ((CaseDoc)(Container.DataItem)).UploadUserName %>
            </td>
            <td>
                <%# ((CaseDoc)(Container.DataItem)).UploadDateTime %>
            </td>
   
            <td>
                 <asp:LinkButton ID="lbtnDownload" Text="下载" CommandName="Select" OnClick = "lbtnDownload_Click" runat="server" />
            </td>
        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>
    <td>暂无相关文档。</td>
    </EmptyDataTemplate>
</asp:ListView>
<button id="btnAdd" runat="server" class="mbutton" onserverclick="btnAdd_Click">+ 添加</button>
<button id="btnDelete" runat="server" class="mbutton" onserverclick="btnDelete_Click">- 删除</button> 
