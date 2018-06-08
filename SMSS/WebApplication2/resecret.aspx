<%@ Page Title="" Language="C#" MasterPageFile="~/StudentM.Master" AutoEventWireup="true" CodeBehind="resecret.aspx.cs" Inherits="WebApplication2.resecret" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" runat="server" Height="40px" HorizontalAlign="Center">
        <asp:Label ID="Label1" runat="server" Text="初始密码   "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" type="password"></asp:TextBox>
    </asp:Panel>
     <asp:Panel ID="Panel1" runat="server" Height="40px" HorizontalAlign="Center">
         <asp:Label ID="Label2" runat="server" Text="新密码    "></asp:Label>
         <asp:TextBox ID="TextBox2" runat="server" type="password"></asp:TextBox>
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server" Height="40px" HorizontalAlign="Center">
         <asp:Label ID="Label3" runat="server" Text="重新输入新密码"></asp:Label>
         <asp:TextBox ID="TextBox3" runat="server" type="password"></asp:TextBox>
        
    </asp:Panel>
     <asp:Panel ID="Panel4" runat="server" HorizontalAlign="Center">
         <asp:Button ID="Button1" runat="server" Text="确认" OnClick="Button1_Click" />
         </asp:Panel>
</asp:Content>
