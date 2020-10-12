using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Handlers
{
    public class HtmlHandler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.WriteFile("index.html");
        }
        public bool IsReusable => true;
    }
}