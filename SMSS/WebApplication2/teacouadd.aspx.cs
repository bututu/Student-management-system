using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class teacouadd : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int confirm = 0;
            SqlConnection conn = new SqlConnection(constr);
            string num = counum.Text.Trim();
            if (num == "")
            {
                confirm = 1;
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "课程编号不能为空" + "');window.location.href ='teacouadd.aspx'</script>");

            }
            conn.Open();
            String sql2 = "select counum from [course] where counum='" + num + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            if (sdr2.Read())
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "该课程编号已被登记" + "');window.location.href ='teacouadd.aspx'</script>");
                confirm = 1;
            }
            conn.Close();
            if (couname.Text.Trim() == "")
            {

                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "课程名称不能为空" + "');window.location.href ='teacouadd.aspx'</script>");
                confirm = 1;
            }
            else if (couteacher.Text.Trim() == "")
            {

                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "任课教师不能为空" + "');window.location.href ='teacouadd.aspx'</script>");
                confirm = 1;
            }
            else if (info.Text.Trim() == "")
            {

                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "课程介绍不能为空" + "');window.location.href ='teacouadd.aspx'</script>");
                confirm = 1;
            }
            //string snum = Session["snum"].ToString();
            //string snum = "201511";
            //  string createtime = DateTime.Now.ToString();
            string name = couname.Text.Trim();  //课程名称
            string teacher = couteacher.Text.Trim();  //任课教师
            string iinfo = info.Text.Trim();  //课程介绍
            
            if (confirm == 0)
            {
                conn.Open();
                //将信息更新到学生表
                string sql = "INSERT INTO [course] (counum,couname,couteacher,info) VALUES('" + num + "','" + name + "','" + teacher + "','" + iinfo +  "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "操作成功" + "');window.location.href ='teacouadd.aspx'</script>");
                conn.Close();
            }
        }
    }
}