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
    public partial class WebForm2 : System.Web.UI.Page
    {
        private string constr = "server=118.25.74.182; Initial Catalog = Studb; Persist Security Info = True; User ID = sa; Password = Lizhiyang1()";
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.RadioButtonList1.Items[0].Selected = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            //Response.Write("打开成功" + conn.State);
            int role = 0;
     
            if (RadioButtonList1.Items[1].Selected == true) {
                role = 1;
               
            }   
            String sql = "select userid , snum from [user] where userid='" + userid.Text + "'and pwd ='"+pwd.Text+"'and role="+role+ "and deletestatus = 0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            SqlDataReader sdr = cmd.ExecuteReader();
            //string userr = dt.Rows[0][0].ToString();
            if (sdr.Read())
            {
                if (role == 0)
                {
                    Session["snum"] = sdr["snum"];
                    Session["UserID"] = userid.Text.Trim();
                    Response.Redirect("stumain.aspx");
                }
                else {
                    Session["TUserID"] = userid.Text.Trim();
                    Response.Redirect("teamain.aspx");
                }
            }
            else {
                ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "账号密码错误请重新输入" + "');window.location.href ='Login.aspx'</script>");
            }

                conn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Session["UserID"] ="lzy123344"

        Response.Write("<script language='javascript'>window.location='signup.aspx'</script>");
        }
    }
}