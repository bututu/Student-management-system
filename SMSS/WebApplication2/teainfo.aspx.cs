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
    public partial class teainfo : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";

        public DataSet GetResult()
        {
           // string snum = Session["snum"].ToString();

            string sql = "select sname 姓名,snum 学号,ssex 性别,sbirth 出生日期,dname 专业名称 from [stu],[specialitie] where [stu].dnum=[specialitie].dnum";

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
            DataSet ds = new DataSet();
            ds = GetResult();
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
        }
    }
}