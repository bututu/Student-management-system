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
            if (Session["UserID"] == null || Session["UserID"].ToString() == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "请先登录" + "');window.location.href ='Login.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>history.go(-2)</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string createtime=DateTime.Now.ToString();
            string sql = "INSERT INTO [user](userid,pwd,email,username,snum,createtime)VALUES('" + userid.Text + "','" +pwd.Text+ "','" +email.Text+ "','" +username.Text+ "','" +snum.Text+ "','"+createtime+"')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "操作成功" + "');window.location.href ='Login.aspx'</script>");
            conn.Close();
        }
    }
}