using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections.Specialized;

namespace Lab_4
{
    /// <summary>
    /// Summary description for Simplex
    /// </summary>
    [WebService(Namespace = "http://yns/", Description = "Simplex Service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class Simplex : System.Web.Services.WebService
    {
        [WebMethod(MessageName = "Sum_1", Description = "Sum of 2 int")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(MessageName = "Sum_2", Description = "Concatination of string and double")]
        public string Concat(string s, double d)
        {
            return s + " " + d.ToString();
        }

        [WebMethod(MessageName = "Sum_3", Description = "Sum of fileds of two [A] objects. Return [A] object")]
        public A Sum(A a1, A a2)
        {
            NameValueCollection t = Context.Request.Params;
            return new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(MessageName = "Sum_4", Description = "Sum of 2 int. Response JSON")]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
}
