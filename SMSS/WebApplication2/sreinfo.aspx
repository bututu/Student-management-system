<%@ Page Title="" Language="C#" MasterPageFile="~/StudentM.Master" AutoEventWireup="true" CodeBehind="sreinfo.aspx.cs" Inherits="WebApplication2.sreinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" runat="server" Height="30px">
        <asp:Label ID="Label1" runat="server" Text="学生姓名"></asp:Label>
        <asp:TextBox ID="sname" runat="server"></asp:TextBox>
    </asp:Panel>

     <asp:Panel ID="Panel1" runat="server" Height="30px">
       <asp:Label ID="Label2" runat="server" Text="学生性别"></asp:Label>
         <asp:DropDownList ID="SexList2" runat="server">
             <asp:ListItem>男</asp:ListItem>
             <asp:ListItem>女</asp:ListItem>
         </asp:DropDownList>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="30px">
        <asp:Label ID="Label4" runat="server" Text="出生日期"></asp:Label>
        <asp:TextBox ID="BirthDay" runat="server" ToolTip="格式xxxx-xx-xx"></asp:TextBox>
        <asp:Label ID="bdtips" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Height="30px">
        <asp:Label ID="Label3" runat="server" Text="学院名称"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="dname" DataValueField="dname">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudbConnectionString %>" SelectCommand="SELECT [dname] FROM [specialitie]"></asp:SqlDataSource>
    </asp:Panel>

      <asp:Panel ID="Panel5" runat="server" Height="30px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认修改" />
        </asp:Panel>
</asp:Content>
