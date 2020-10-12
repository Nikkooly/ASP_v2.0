using lab2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace lab2.Strategies
{
    public class PushStack : BaseStrategy
    {
        public int NumberToAdd { get; set; }

        protected override void Process()
        {
            CacheResult.PushToStack(NumberToAdd);
        }
    }
}