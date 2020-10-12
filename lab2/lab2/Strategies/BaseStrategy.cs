using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace lab2.Strategies
{
    public abstract class BaseStrategy
    {
        public virtual object Execute(HttpControllerContext context)
        {
            Process();
            return CacheResult.Result;
        }

        protected virtual void Process()
        {

        }
    }
}