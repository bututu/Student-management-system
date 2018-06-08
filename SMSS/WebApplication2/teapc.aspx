<%@ Page Title="" Language="C#" MasterPageFile="~/TeacherT.Master" AutoEventWireup="true" CodeBehind="teapc.aspx.cs" Inherits="WebApplication2.teapc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Panel ID="Panel6" runat="server" Height="30px">
         <asp:Label ID="Label5" runat="server" Text="输入学生学号"></asp:Label>
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
         <asp:Button ID="Button2" runat="server" Text="开始搜索" OnClick="Button2_Click" />

        </asp:Panel>
    <asp:Panel ID="Panel8" runat="server" Visible="false">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns>
              <asp:BoundField HeaderText="姓名" DataField="姓名"  HtmlEncode= "false" >
        </asp:BoundField>  
            <asp:BoundField HeaderText="学号" DataField="学号"  HtmlEncode= "false" >
        </asp:BoundField>  
            <asp:BoundField HeaderText="性别" DataField="性别"  HtmlEncode= "false" >
        </asp:BoundField>  
          <asp:BoundField HeaderText="出生日期" DataField="出生日期"  HtmlEncode= "false" DataFormatString="{0:yyyy-MM-dd}">
        </asp:BoundField>  
            <asp:BoundField HeaderText="专业名称" DataField="专业名称"  HtmlEncode= "false" >
        </asp:BoundField>  
            </Columns>
        </asp:GridView>

    </asp:Panel>

</asp:Content>
