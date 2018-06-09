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
    public partial class teacancle : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public DataSet GetResult()
        {
            string snum = TextBox1.Text.Trim();
            if (snum == "")
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "学号不能为空" + "');window.location.href ='teareinfo.aspx'</script>");
            }
            string sql = "select sname 姓名,snum 学号,ssex 性别,sbirth 出生日期,dname 专业名称 from [stu],[specialitie] where snum='" + snum + "' and [stu].dnum=[specialitie].dnum";

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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string snum = TextBox1.Text.Trim();
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sql = "DELETE FROM [stu] WHERE snum='"+snum+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "操作成功" + "');window.location.href ='teareinfo.aspx'</script>");
            conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string snum = TextBox1.Text.Trim();
            ds = GetResult();
            if (ds.Tables[0].Rows.Count != 0)
            {
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                Panel7.Visible = true;
                Panel8.Visible = true;


            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "学号不存在" + "');window.location.href ='teacancle.aspx'</script>");
            }
        }
    }
}