<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="发明人.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="Homework.PatentApplicationSystem.ClientInfoMange.发明人" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <table>
        <asp:ListView ID="ListView1" OnSelectedIndexChanged="ListView1SelectedIndexChanged" OnSelectedIndexChanging="ListView1SelectedIndexChanging" DataKeyNames="身份证号" runat="server" >
    <LayoutTemplate>
     
            <thead>

                    <th scope="col">
                        身份证号
                    </th>
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
                <%# ((Inventor)Container.DataItem).身份证号 %>
            </td>
            <td>
                <%# ((Inventor)Container.DataItem).姓名%>
            </td>
            <td>
                <%# ((Inventor)Container.DataItem).电话%>
            </td>
            <td>
                <%# ((Inventor)Container.DataItem).Email%>
            </td>
            <td>
                <asp:LinkButton ID="lBtnDelete" CommandName="Select" Text="X" runat="server" />
            </td>

        </tr>
    </ItemTemplate>
    <EmptyDataTemplate>无发明人信息，请添加</EmptyDataTemplate>
    </asp:ListView>
    <tr>
        <td>
             <asp:TextBox ID="Uid" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Name" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Tel" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="Email" runat="server"></asp:TextBox>   
        </td>
        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />

    </div>
</asp:Content>