using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Main
{
    public class ReturnMessage : BaseStrategy
    {
        public override int Execute(HttpContext context)
        {
            context.Response.Write(JsonConvert.SerializeObject(Result));
            return base.Execute(context);
        }

        public ReturnMessage(int result) : base(result)
        {
        }
    }
}