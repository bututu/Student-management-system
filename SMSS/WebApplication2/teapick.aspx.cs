using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class teapick : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        public DataSet GetResult()
        {
            string snum = TextBox1.Text.Trim();
            if (snum == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "学号不能为空" + "');window.location.href ='teapick.aspx'</script>");
            }
            string sql = "select snum 学号,couname 课程名称,couteacher 任课老师,info 课程介绍 from [pick],[course] where snum='" + snum + "' and [pick].counum=[course].counum";

            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, conn);
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataSet GetResult2()
        {
            //string snum = Session["snum"].ToString();

            string sql = "select counum 课程编号,couname 课程名字 from [course] ";

            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, conn);
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            return ds;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = GetResult();
            if (ds.Tables[0].Rows.Count != 0)
            {
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();

                Panel8.Visible = true;
                Panel3.Visible = true;

            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "学号不存在" + "');window.location.href ='teapick.aspx'</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string counum = coulist.SelectedItem.Text;
            string snum = TextBox1.Text.Trim();
            SqlConnection conn = new SqlConnection(constr);
            int confirm = 0;
            conn.Open();
            String sql1 = "select id from [pick] where counum='" + counum + "' and snum ='" + snum + "'";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                confirm = 1;
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "已经选过相同课程" + "');window.location.href ='teapick.aspx'</script>");
            }
            conn.Close();
            if (confirm == 0)
            {
                conn.Open();
                string sql = "INSERT INTO [pick](snum,counum)VALUES('" + snum + "','" + counum + "')";
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                int rows = cmd1.ExecuteNonQuery();
                if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "选课成功" + "');window.location.href ='teapick.aspx'</script>");
                conn.Close();

            }
        }
    }
}