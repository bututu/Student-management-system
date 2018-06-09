<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherT.Master" AutoEventWireup="true" CodeBehind="teacouadd.aspx.cs" Inherits="WebApplication2.teacouadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel7" runat="server" Height="30px">
        <asp:Label ID="Label5" runat="server" Text="课程编号"></asp:Label>
        <asp:TextBox ID="counum" runat="server"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Height="30px">
        <asp:Label ID="Label1" runat="server" Text="课程名称"></asp:Label>
        <asp:TextBox ID="couname" runat="server"></asp:TextBox>
    </asp:Panel>

     <asp:Panel ID="Panel1" runat="server" Height="30px">
       <asp:Label ID="Label2" runat="server" Text="任课教师"></asp:Label>
         <asp:TextBox ID="couteacher" runat="server"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Height="30px">
        <asp:Label ID="Label4" runat="server" Text="课程介绍"></asp:Label>
        <asp:TextBox ID="info" runat="server" ></asp:TextBox>
        
    </asp:Panel>


      <asp:Panel ID="Panel5" runat="server" Height="30px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认添加" />
        </asp:Panel>
</asp:Content>
