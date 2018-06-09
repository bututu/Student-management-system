using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class resecret : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            string userid = "";
            if (Session["UserID"] != null)
            {
                userid = Session["UserID"].ToString();
            }
          //  string userid = Session["UserID"].ToString();
            int confirm = 0;
            if (TextBox1.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "初始密码不能为空" + "');window.location.href ='resecret.aspx'</script>");
            }
            //查询初始密码是否正确
            conn.Open();
            String sql2 = "select pwd from [user] where userid='" + userid+ "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
           
            if (sdr2.Read())
            {
                if (sdr2["pwd"].ToString() != TextBox1.Text.Trim()) {
                    conn.Close();
                    ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "初始密码错误" + "');window.location.href ='resecret.aspx'</script>");
                    confirm = 1;
                }
                else
                {
                    conn.Close();
                }
            } 
              
            if (TextBox2.Text.Trim() == TextBox3.Text.Trim() && TextBox2.Text.Trim() != ""&&confirm==0) {
                conn.Open();
                //将信息更新到学生表
                string sql = "update [user] set pwd='"+TextBox2.Text.Trim()+"'where userid='"+userid+"' and role=0";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "操作成功" + "');window.location.href ='resecret.aspx'</script>");
                conn.Close();
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "新密码为空或两遍不相同" + "');window.location.href ='resecret.aspx'</script>");
            }



        }
    }
}