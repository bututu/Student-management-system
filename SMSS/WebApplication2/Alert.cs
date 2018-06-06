using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Alert
    {
        public static void AlertLogin(string Message, string RedirectUrl)
        {
            string alert = "<script language='javascript'>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(alert, Message, RedirectUrl));
        }
    }
}