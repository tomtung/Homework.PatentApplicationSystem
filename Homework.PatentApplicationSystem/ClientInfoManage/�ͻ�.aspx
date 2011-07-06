<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="客户.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Homework.PatentApplicationSystem.ClientInfoManage.客户" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
        <asp:ListView ID="ListView1" OnSelectedIndexChanged="ListView1SelectedIndexChanged" OnSelectedIndexChanging="ListView1SelectedIndexChanging" DataKeyNames="客户号" runat="server" >
    <LayoutTemplate>
     
            <thead>

                    <th scope="col">
                        客户号
                    </th>
                    <th scope="col">
                        类型
                    </th>
                    <th scope="col">
                       地址
                    </th>
                    <th scope="col">
                        邮编
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
                <%# ((Customer)Container.DataItem).客户号 %>
            </td>
            <td>
                <%# ((Customer)Container.DataItem).类型%>
            </td>
            <td>
                <%# ((Customer)Container.DataItem).地址%>
            </td>
            <td>
                <%# ((Customer)Container.DataItem).邮编 %>
            </td>
            <td>
                <asp:LinkButton ID="lBtnDelete" CommandName="Select" Text="X" runat="server" />
            </td>

        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>无客户信息，请添加</EmptyDataTemplate>
    </asp:ListView>
    <tr>
        <td>
             <asp:TextBox ID="Uid" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Type" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Address" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="ZipCode" runat="server"></asp:TextBox>   
        </td>
        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="Button1" class="mbutton" runat="server" Text="添加" onclick="Button1_Click" />
    </div>
</asp:Content>
