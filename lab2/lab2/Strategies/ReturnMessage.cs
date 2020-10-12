using lab2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace lab2.Strategies
{
    public class ReturnMessage : BaseStrategy
    {
        public override object Execute(HttpControllerContext context)
        {
            return JsonConvert.SerializeObject(CacheResult.Result);
        }

    }
}