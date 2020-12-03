using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class ResJsonRPCError
    {
        public string Key { get; set; }
        public string JsonRPC { get; set; }
        public ErrorJsonRPC Error { get; set; }
    }
}