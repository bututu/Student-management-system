<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学生管理系统</title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
            width: 100%;
        }
        .auto-style2 {
            width: 45%;
        }
        .auto-style3 {
            height: 20px;
            width: 45%;
        }
        .auto-style7 {
            width: 100%;
        }
        .auto-style8 {
            height: 27px;
        }
        .auto-style9 {
            height: 20px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <table class="auto-style7"><thead>
            <tr>
            <th  colspan="2" class="auto-style9" >学生信息管理系统</th>

            </tr>
        </thead>
        <tr class="auto-style1"> 
            <td class="auto-style2" style="text-align:right" >用户名:</td>
            <td class="auto-style2"  >
            <asp:TextBox ID="userid" runat="server"></asp:TextBox>
            </td>
          
        </tr>
        <tr>
            <td class="auto-style3" style="text-align:right" >密  码:</td>
            <td class="auto-style3"  >
                
         <asp:TextBox ID="pwd" runat="server"  type="password"></asp:TextBox>
                 </td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2" >
                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                    <asp:Button ID="Button1" runat="server" Text="登陆" Height="30px" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="注册" Height="30px" OnClick="Button2_Click"/>

                    </asp:Panel>
            </td>
          
        </tr>
               <tr><td class="auto-style8" colspan="2" >
                   <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                       <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">学生登陆</asp:ListItem>
                          <asp:ListItem Value="2">教师登陆</asp:ListItem>
                       </asp:RadioButtonList>
                   </asp:Panel>
                   </td>
              </tr>
    </table>
        </div>
    </form>
</body>
</html>
