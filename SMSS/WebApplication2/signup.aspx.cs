using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class signup : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserID"] == null || Session["UserID"].ToString() == "")
            //{
            //    ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "请先登录" + "');window.location.href ='Login.aspx'</script>");
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>history.go(-2)</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            int confirm = 0;
            if (userid.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "账号不能为空" + "');window.location.href ='signup.aspx'</script>");
                confirm = 1;
            }
            //查询账号是否被注册
            conn.Open();
            String sql2 = "select userid from [user] where userid='"+userid.Text.Trim()+"'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            if (sdr2.Read())
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "该账号已被注册" + "');window.location.href ='signup.aspx'</script>");
                confirm = 1;
            }
            conn.Close();
            if (pwd.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "密码不能为空" + "');window.location.href ='signup.aspx'</script>");
                confirm = 1;
            }
            if (username.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "姓名不能为空" + "');window.location.href ='signup.aspx'</script>");
                confirm = 1;
            }
            if (snum.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "学号不能为空" + "');window.location.href ='signup.aspx'</script>");
                confirm = 1;
            }
            //查询学号姓名是否被注册
            conn.Open();
            String sql1 = "select [user].snum from [stu],[user] where [user].snum=[stu].snum and [stu].snum='"+snum.Text.Trim()+"' and sname='"+username.Text.Trim()+"'";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "该学号+姓名组合已被注册或不存在" + "');window.location.href ='signup.aspx'</script>");
                confirm = 1;
            }
            conn.Close();
            if (confirm == 0) { 
            conn.Open();
            string createtime=DateTime.Now.ToString();
            string sql = "INSERT INTO [user](userid,pwd,email,username,snum,createtime)VALUES('" + userid.Text + "','" +pwd.Text+ "','" +email.Text+ "','" +username.Text+ "','" +snum.Text+ "','"+createtime+"')";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            int rows = cmd1.ExecuteNonQuery();
            if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "注册成功" + "');window.location.href ='Login.aspx'</script>");
            conn.Close();
            }
        }
    }
}