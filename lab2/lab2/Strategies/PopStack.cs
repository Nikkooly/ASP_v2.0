using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab2.Strategies
{
    public class PopStack : BaseStrategy
    {
        protected override void Process()
        {
            CacheResult.PopStack();
        }
    }
}