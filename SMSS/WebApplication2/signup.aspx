<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="WebApplication2.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;height:60px">
            <asp:Label ID="Label1" runat="server" Text="账  号:"></asp:Label>
            <asp:TextBox ID="userid" runat="server"></asp:TextBox>
        </div>
         <div style="text-align:center;height:60px">
            <asp:Label ID="Label2" runat="server" Text="密  码:"></asp:Label>
            <asp:TextBox ID="pwd" runat="server"></asp:TextBox>
        </div>
         <div style="text-align:center;height:60px">
            <asp:Label ID="Label3" runat="server" Text="邮  箱:"></asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </div>
         <div style="text-align:center;margin-right:25px;height:60px">
            <asp:Label ID="Label4" runat="server" Text="真实姓名:"></asp:Label>
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </div>
        <div style="text-align:center;height:60px">
            <asp:Label ID="Label5" runat="server" Text="学  号:"></asp:Label>
            <asp:TextBox ID="snum" runat="server"></asp:TextBox>
        </div>
        <div style="text-align:center;height:60px">
            <asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
