<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="客户管理.aspx.cs" Inherits="Homework.PatentApplicationSystem.客户管理" %>
<%@MasterType TypeName="Homework.PatentApplicationSystem.SiteMaster" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model" %>
<%@ Import Namespace="Homework.PatentApplicationSystem.Model.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="nav2">
    <user:Tab ID="TabStrip" runat="server" OnTabClick="TabStrip_Click" />
</div>
<asp:MultiView ID="MultiView" ActiveViewIndex="0" runat="server">
    <asp:View ID="客户" runat="server">
          <div>
        <table>
                    <thead>
                    <tr>
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
        <asp:ListView ID="CustomerListView" OnSelectedIndexChanged="CustomerListView_SelectedIndexChanged" OnSelectedIndexChanging="CustomerListView_SelectedIndexChanging" DataKeyNames="客户号" runat="server" >
    <LayoutTemplate>
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
             <asp:TextBox ID="CustomerUid" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerType" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerAddress" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerZipCode" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="AddCustomerButton" class="mbutton" runat="server" Text="添加" onclick="AddCustomerButton_Click" />
    </div>
    </asp:View>
    <asp:View ID="客户联系人" runat="server">
        <div id="main">
            <table>
                        <thead>
            <tr>
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
        <asp:ListView ID="CustomerContactListView" OnSelectedIndexChanged="CustomerContactListView_SelectedIndexChanged" OnSelectedIndexChanging="CustomerContactListView_SelectedIndexChanging" DataKeyNames="姓名" runat="server" >
    <LayoutTemplate>
     

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
             <asp:TextBox ID="CustomerContactName" Width="100px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerContactTel" Width="100px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerContactEmail" Width="100px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerContactType" Width="100px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="CustomerContactCustomerID" Width="100px" runat="server"></asp:TextBox>   
        </td>
        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="AddCustomerContactListViewButton" runat="server" class="mbutton" Text="添加" onclick="AddCustomerContactListViewButton_Click" />

    </div>

    </asp:View>
    <asp:View ID="申请人" runat="server">
            <div id="Div1">
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
        <asp:ListView ID="ApplicantListView" OnSelectedIndexChanged="ApplicantListView_SelectedIndexChanged" OnSelectedIndexChanging="ApplicantListView_SelectedIndexChanging" DataKeyNames="证件号" runat="server" >
    <LayoutTemplate>
     

            <tbody>
                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
            </tbody>
        
    </LayoutTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# ((Applicant)Container.DataItem).证件号 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).类型 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).中文名 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).英文名 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).简称 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).国家 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).省 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).市区县 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).中国地址 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).外国地址 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).邮编 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).电话 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).传真 %>
            </td>
            <td>
                <%# ((Applicant)Container.DataItem).Email %>
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
             <asp:TextBox ID="申请人证件号" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人类型" Width="40px" runat="server"></asp:TextBox>          
</td>

 <td>
             <asp:TextBox ID="申请人中文名" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人英文名" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人简称" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人国家" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人省" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人市区县" Width="40px" runat="server"></asp:TextBox>          
</td>
 <td>
             <asp:TextBox ID="申请人中国地址" Width="40px" runat="server"></asp:TextBox>          
</td>
 <td>
             <asp:TextBox ID="申请人外国地址" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人邮编" Width="40px" runat="server"></asp:TextBox>           
</td>
<td>
             <asp:TextBox ID="申请人电话" Width="40px" runat="server"></asp:TextBox>          
</td>
 <td>
             <asp:TextBox ID="申请人传真" Width="40px" runat="server"></asp:TextBox>   
</td>
 <td>
             <asp:TextBox ID="申请人Email" Width="40px" runat="server"></asp:TextBox>   
</td>

        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="AddApplicantButton" runat="server" class="mbutton" Text="添加" onclick="AddApplicantButton_Click" />

    </div>
    </asp:View>
    <asp:View ID="发明人" runat="server">
       <div>
            <table>
                        <thead>
            <tr>
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
        <asp:ListView ID="InventorListView" OnSelectedIndexChanged="InventorListView_SelectedIndexChanged" OnSelectedIndexChanging="InventorListView_SelectedIndexChanging" DataKeyNames="身份证号" runat="server" >
    <LayoutTemplate>
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
             <asp:TextBox ID="InventorUid" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="InventorName" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="InventorTel" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td>
             <asp:TextBox ID="InventorEmail" Width="120px" runat="server"></asp:TextBox>   
        </td>
        <td />
     </tr>
    </table>
    <br />
    <asp:Button ID="AddInventorButton" class="mbutton" runat="server" Text="添加" onclick="AddInventorButton_Click" />

    </div>
    </asp:View>
</asp:MultiView>
</asp:Content>
