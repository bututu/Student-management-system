using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class StudentM : System.Web.UI.MasterPage
    {
        string snum="";
        protected void Page_Load(object sender, EventArgs e)
        {
           // string snum = "";
            if (Session["snum"] != null)
            {
                snum = Session["snum"].ToString();
            }
            if (Session["UserID"] == null || Session["UserID"].ToString() == "")
            {
                //this.Page.ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "请先登录" + "');window.location.href ='Login.aspx'</script>");
                Response.Write("<script>alert('" + "请先登录" + "');window.location.href ='Login.aspx'</script>");
            }
        }
     
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            //if (e.Item.Value == "首页")
            //{
            //    Response.Redirect("stumain.aspx");
            //}
        }

        protected void Menu1_MenuItemClick1(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "首页")
            {
                Response.Redirect("stumain.aspx");
            }
            else if(e.Item.Value== "学生信息查询")
            {
                Response.Redirect("sinfo.aspx");
            }
            else if (e.Item.Value == "学生信息修改")
            {
                Response.Redirect("sreinfo.aspx");
            }
            else if (e.Item.Value == "课程查询")
            {
                Response.Redirect("course.aspx");
            }
            else if (e.Item.Value=="学生选课查询")
            {
                Response.Redirect("severpc.aspx");
            }
            else if (e.Item.Value == "网上选课")
            {
                Response.Redirect("pick.aspx");
            }
            else if (e.Item.Value == "密码修改")
            {
                Response.Redirect("resecret.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserID"] = "";
            Session["snum"] = "";
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "print", "<script>alert('" + "退出成功" + "');window.location.href ='login.aspx'</script>");
        }
    }
}