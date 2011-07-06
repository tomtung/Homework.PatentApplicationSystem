<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="申请人.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Homework.PatentApplicationSystem.ClientInfoManage.申请人" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
            <table>
             <thead>
            <tr>
                    <th scope="col">
                        证件号
                    </th>
                    <th scope="col">
                        类型
                    </th>
                    <th scope="col">
                       中文名
                    </th>
                    <th scope="col">
                        英文名
                    </th>
                    <th scope="col">
                        简称
                    </th>
                    <th scope="col">
                        类型
                    </th>
                    <th scope="col">
                        中文名
                    </th>
                    <th scope="col">
                        英文名
                    </th>
                    <th scope="col">
                        简称
                    </th>
                    <th scope="col">
                        国家
                    </th>
                    <th scope="col">
                        省
                    </th>
                    <th scope="col">
                        市区县
                    </th>
                    <th scope="col">
                        中国地址
                    </th>
                    <th scope="col">
                        外国地址
                    </th>
                    <th scope="col">
                        邮编
                    </th>
                    <th scope="col">
                        电话
                    </th>
                    <th scope="col">
                        传真
                    </th>
                    <th scope="col">
                        Email
                    </th>

                    <th scope="col">
                        
                    </th>

                </tr>
            </thead>
        <asp:ListView ID="ListView1" OnSelectedIndexChanged="ListView1SelectedIndexChanged" OnSelectedIndexChanging="ListView1SelectedIndexChanging" DataKeyNames="证件号" runat="server" >
    <LayoutTemplate>
     

            <tbody>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </tbody>
        
    </LayoutTemplate>
    <ItemTemplate>
        <tr>

            <td>
                <%# ((Applicant)Container.DataItem).类型 %>
            <td>
                <%# ((Applicant)Container.DataItem).中文名 %>
            <td>
                <%# ((Applicant)Container.DataItem).英文名 %>
            <td>
                <%# ((Applicant)Container.DataItem).简称 %>
            <td>
                <%# ((Applicant)Container.DataItem).国家 %>
            <td>
                <%# ((Applicant)Container.DataItem).省 %>
            <td>
                <%# ((Applicant)Container.DataItem).市区县 %>
            <td>
                <%# ((Applicant)Container.DataItem).中国地址 %>
            <td>
                <%# ((Applicant)Container.DataItem).外国地址 %>
            <td>
                <%# ((Applicant)Container.DataItem).邮编 %>
            <td>
                <%# ((Applicant)Container.DataItem).电话 %>
            <td>
                <%# ((Applicant)Container.DataItem).传真 %>
            <td>
                <%# ((Applicant)Container.DataItem).Email %>
            <td>
                <asp:LinkButton ID="lBtnDelete" CommandName="Select" Text="X" runat="server" />
            </td>

        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>无客户联系人信息，请添加</EmptyDataTemplate>
    </asp:ListView>
    <tr>
        <td>
             <asp:TextBox ID="证件号" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="类型" Width="40px" runat="server"></asp:TextBox>          
</td>

 <td>
             <asp:TextBox ID="中文名" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="英文名" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="简称" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="国家" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="省" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="市区县" Width="40px" runat="server"></asp:TextBox>          
</td>
 <td>
             <asp:TextBox ID="中国地址" Width="40px" runat="server"></asp:TextBox>          
</td>
 <td>
             <asp:TextBox ID="外国地址" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="邮编" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="电话" Width="40px" runat="server"></asp:TextBox>          
</td>
 <td>
             <asp:TextBox ID="传真" Width="40px" runat="server"></asp:TextBox>   
</td>
 <td>
             <asp:TextBox ID="Email" Width="40px" runat="server"></asp:TextBox>   
</td>

        </td>
        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" class="mbutton" Text="添加" onclick="Button1_Click" />

    </div>
</asp:Content>