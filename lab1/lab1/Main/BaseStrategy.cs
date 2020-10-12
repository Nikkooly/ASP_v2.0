using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Main
{
    public abstract class BaseStrategy
    {
        protected int Result { get; set; }

        public BaseStrategy(int result)
        {
            Result = result;
        }

        public virtual int Execute(HttpContext context)
        {
            return Result;
        }
    }
}