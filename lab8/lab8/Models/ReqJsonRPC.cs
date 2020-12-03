using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class ReqJsonRPC
    {
        public string Key { get; set; }
        public string JsonRPC { get; set; }
        public string Method { get; set; }
        public DataModel Params { get; set; }
    }
}