using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class TeacherT : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TUserID"] == null || Session["TUserID"].ToString() == "")
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "请先登录" + "');window.location.href ='Login.aspx'</script>");
            }

        }

        protected void Menu1_MenuItemClick1(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "首页")
            {
                Response.Redirect("teamain.aspx");
            }
            else if (e.Item.Value == "全部学生信息")
            {
                Response.Redirect("teainfo.aspx");
            }
            else if (e.Item.Value == "学生信息修改")
            {
                Response.Redirect("teareinfo.aspx");
            }
            else if (e.Item.Value == "课程查询")
            {
                Response.Redirect("teacourse.aspx");
            }
            else if (e.Item.Value == "学生选课查询")
            {
                Response.Redirect("teapc.aspx");
            }
            else if (e.Item.Value == "学生选课信息修改")
            {
                Response.Redirect("teapick.aspx");
            }
           
            else if (e.Item.Value == "学生信息添加")
            {
                Response.Redirect("teaadd.aspx");
            }
            else if (e.Item.Value == "学生信息删除")
            {
                Response.Redirect("teacancle.aspx");
            }
        }

        protected void button1_click(object sender, EventArgs e)
        {
            Session["TUserID"] = "";
            //Session["snum"] = "";
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "退出成功" + "');window.location.href ='login.aspx'</script>");
        }
    }
}