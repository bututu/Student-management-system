using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class sreinfo : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int confirm = 0;
           
            if (sname.Text.Trim() == "")
            {
                
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "姓名不能为空" + "');window.location.href ='sreinfo.aspx'</script>");
                confirm = 1;
            }
            else if (BirthDay.Text.Trim() == "")
            {

                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "出生日期不能为空" + "');window.location.href ='sreinfo.aspx'</script>");
                confirm = 1;
            }

            string snum = "";
            if (Session["snum"] != null)
            {
                snum = Session["snum"].ToString();
            }
            //string snum = "201511";
            string createtime = DateTime.Now.ToString();
            string name = sname.Text;  //学生姓名
            string sex = SexList2.SelectedItem.Text;  //学生性别
            string dname = DropDownList1.SelectedItem.Text;  //学生学院名称
            DateTime date = DateTime.MinValue;
            bool flag = DateTime.TryParse(BirthDay.Text, out date);
            string birth="";
            if (flag)
            {
                birth = date.ToString("yyyy-MM-dd");
                //ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + birth + "');window.location.href ='sreinfo.aspx'</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "出生日期格式错误" + "');window.location.href ='sreinfo.aspx'</script>");
                confirm = 1;
            }
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //查找专业名的专业编号
            string sql1 = "select dnum from [specialitie] where dname='"+dname+"'";
            SqlCommand dnumcmd = new SqlCommand(sql1, conn);
            SqlDataReader sdr = dnumcmd.ExecuteReader();
            string dnum="";
            while (sdr.Read()) { 
            dnum = sdr["dnum"].ToString();
               // ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + dnum + "');window.location.href ='sreinfo.aspx'</script>");
            }
            conn.Close();
            if(confirm == 0) {
            conn.Open();
            //将信息更新到学生表
            string sql = "update [stu] set sname='"+name+"',ssex='"+sex+"',sbirth='"+birth+"',dnum='"+dnum+"' where snum ='"+snum+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0) ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "操作成功" + "');window.location.href ='sreinfo.aspx'</script>");
            conn.Close();
            }
        }
    }
}