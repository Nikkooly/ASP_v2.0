using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Main
{
    public class PushStack : BaseStrategy
    {
        public override int Execute(HttpContext context)
        {
            if (context.Session["Stack"] is Stack<int> stack && int.TryParse(context.Request.Params.Get("ADD"), out var numberToPush))
            {
                stack.Push(numberToPush);
                Result += numberToPush;
            }

            return base.Execute(context);
        }

        public PushStack(int result) : base(result)
        {
        }
    }
}