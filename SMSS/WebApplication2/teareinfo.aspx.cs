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
    public partial class teareinfo : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public DataSet GetResult()
        {
            string snum = TextBox1.Text.Trim();
            if (snum == "") {
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
        protected void Button2_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            string snum = TextBox1.Text.Trim();
            ds = GetResult();
            if (ds.Tables[0].DefaultView != null)
            {
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                Panel7.Visible = true;
                Panel8.Visible = true;

            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "学号不存在" + "');window.location.href ='teareinfo.aspx'</script>");

            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int confirm = 0;
            string snum = TextBox1.Text.Trim();
            if (sname.Text.Trim() == "")
            {

                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "姓名不能为空" + "');window.location.href ='teareinfo.aspx'</script>");
                confirm = 1;
            }
            else if (BirthDay.Text.Trim() == "")
            {

                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "出生日期不能为空" + "');window.location.href ='teareinfo.aspx'</script>");
                confirm = 1;
            }

            //string snum = Session["snum"].ToString();
            //string snum = "201511";
            string createtime = DateTime.Now.ToString();
            string name = sname.Text;  //学生姓名
            string sex = SexList2.SelectedItem.Text;  //学生性别
            string dname = DropDownList1.SelectedItem.Text;  //学生学院名称
            DateTime date = DateTime.MinValue;
            bool flag = DateTime.TryParse(BirthDay.Text, out date);
            string birth = "";
            if (flag)
            {
                birth = date.ToString("yyyy-MM-dd");
                //ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + birth + "');window.location.href ='sreinfo.aspx'</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "出生日期格式错误" + "');window.location.href ='teareinfo.aspx'</script>");
                confirm = 1;
            }
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //查找专业名的专业编号
            string sql1 = "select dnum from [specialitie] where dname='" + dname + "'";
            SqlCommand dnumcmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr = dnumcmd.ExecuteReader();
            string dnum = "";
            while (sdr.Read())
            {
                dnum = sdr["dnum"].ToString();
                // ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + dnum + "');window.location.href ='sreinfo.aspx'</script>");
            }
            conn.Close();
            if (confirm == 0)
            {
                conn.Open();
                //将信息更新到学生表
                string sql = "update [stu] set sname='" + name + "',ssex='" + sex + "',sbirth='" + birth + "',dnum='" + dnum + "' where snum ='" + snum + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "操作成功" + "');window.location.href ='teareinfo.aspx'</script>");
                conn.Close();
            }
        }
    }
}