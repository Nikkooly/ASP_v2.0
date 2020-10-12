using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Main
{
    public class PopStack : BaseStrategy
    {
        public override int Execute(HttpContext context)
        {
            if (context.Session["Stack"] is Stack<int> stack && stack.Any())
            {
                Result += stack.Pop();
            }
            return base.Execute(context);
        }

        public PopStack(int result) : base(result)
        {
        }
    }
}