using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1.Main
{
    public class EditResult : BaseStrategy
    {
        public override int Execute(HttpContext context)
        {
            var resultToAdd = context.Request.Params.Get("RESULT");
            int.TryParse(resultToAdd, out var numberToAdd);
            Result += numberToAdd;
            return base.Execute(context);
        }

        public EditResult(int result) : base(result)
        {
        }
    }
}