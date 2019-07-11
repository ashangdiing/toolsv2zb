using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace avayaBusyrel
{
    /// <summary>
    /// runbat 的摘要说明
    /// </summary>
    public class runbat : IHttpHandler
    {
        String trunkname = "";
        public void ProcessRequest(HttpContext context)
        {
            trunkname=context.Request["trunkname"];
            telnet tel = new telnet("14.23.151.178", "dadmin", "esun5005",5005, "dadmin01");
         //   System.Threading.Thread.Sleep(1000);
            context.Response.Redirect("Default.aspx");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}