<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="客户联系人.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="Homework.PatentApplicationSystem.ClientInfoMange.客户联系人" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <table>
        <asp:ListView ID="ListView1" OnSelectedIndexChanged="ListView1SelectedIndexChanged" OnSelectedIndexChanging="ListView1SelectedIndexChanging" DataKeyNames="客户号" runat="server" >
    <LayoutTemplate>
     
            <thead>

                    <th scope="col">
                        姓名
                    </th>
                    <th scope="col">
                        电话
                    </th>
                    <th scope="col">
                       Email
                    </th>
                    <th scope="col">
                        联系人类型
                    </th>
                    <th scope="col">
                        客户号
                    </th>
                    <th scope="col">
                        
                    </th>

                </tr>
            </thead>
            <tbody>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </tbody>
        
    </LayoutTemplate>
    <ItemTemplate>
        <tr>

            <td>
                <%# ((CustomerContact)Container.DataItem).姓名 %>
            </td>
            <td>
                <%# ((CustomerContact)Container.DataItem).电话 %>
            </td>
            <td>
                <%# ((CustomerContact)Container.DataItem).Email %>
            </td>
            <td>
                <%# ((CustomerContact)Container.DataItem).联系人类型 %>
            </td>
            <td>
                <%# ((CustomerContact)Container.DataItem).客户号 %>
            </td>
            <td>
                <asp:LinkButton ID="lBtnDelete" CommandName="Select" Text="X" runat="server" />
            </td>

        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>无客户联系人信息，请添加</EmptyDataTemplate>
    </asp:ListView>
    <tr>
        <td>
             <asp:TextBox ID="Name" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Tel" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Email" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Type" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerID" runat="server"></asp:TextBox>   
        </td>
        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />

    </div>
</asp:Content>