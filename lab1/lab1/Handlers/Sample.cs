using lab1.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace lab1.Handlers
{
    public class Sample : IHttpHandler, IRequiresSessionState
    {
        private BaseStrategy strategy;

        private int _result { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    strategy = new ReturnMessage(_result);
                    break;
                case "PUT":
                    AddSessionIfNeeded(context);
                    strategy = new PushStack(_result);
                    break;
                case "POST":
                    strategy = new EditResult(_result);
                    break;
                case "DELETE":
                    AddSessionIfNeeded(context);
                    strategy = new PopStack(_result);
                    break;
                default:
                    response.Write("Something happened. Sorry");
                    break;
            }

            _result = strategy.Execute(context);
        }

        public bool IsReusable { get; } = true;

        private void AddSessionIfNeeded(HttpContext context)
        {
            if (context.Session["Stack"] == null)
            {
                context.Session["Stack"] = new Stack<int>();
            }
        }
    }
}