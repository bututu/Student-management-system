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
    public partial class teapc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        public DataSet GetResult()
        {
            string snum =TextBox1.Text.Trim();
            if (snum == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "学号不能为空" + "');window.location.href ='teapc.aspx'</script>");
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = GetResult();
            if (ds.Tables[0] != null)
            {
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
               
                Panel8.Visible = true;


            }
        }
    }
}