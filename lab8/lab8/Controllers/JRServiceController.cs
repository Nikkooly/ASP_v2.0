using lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace lab8.Controllers
{
    public class JRServiceController : Controller
    {
        private static bool ignoreMethods = false;

        [System.Web.Http.HttpPost]
        public JsonResult Multi([FromBody] ReqJsonRPC[] body)
        {
            int length = body.Length;
            JsonResult[] result = new JsonResult[length];

            for (int i = 0; i < length; i++)
                result[i] = Single(body[i]);

            return Json(result);
        }

        [System.Web.Http.HttpPost]
        public JsonResult Single(ReqJsonRPC body)
        {
            if (ignoreMethods)
                return Json(GetError(body.Params.Key, body.JsonRPC, new ErrorJsonRPC { Message = "Methods are don't available", Code = -40001 }));

            string method = body.Method;
            DataModel param = body.Params;
            string key = param.Key;
            int value = int.Parse(param.Value == null || param.Value == "" ? "0" : param.Value); // default value = 0
            int? result = null;

            switch (method)
            {
                case "SetM":
                    {
                        result = SetM(key, value);
                        break;
                    }
                case "GetM":
                    {
                        result = GetM(key);
                        break;
                    }
                case "AddM":
                    {
                        result = AddM(key, value);
                        break;
                    }
                case "SubM":
                    {
                        result = SubM(key, value);
                        break;
                    }
                case "MulM":
                    {
                        result = MulM(key, value);
                        break;
                    }
                case "DivM":
                    {
                        result = DivM(key, value);
                        break;
                    }
                case "ErrorExit":
                    {
                        ErrorExit();
                        break;
                    }
                default:
                    {
                        return Json(GetError(body.Params.Key, body.JsonRPC, new ErrorJsonRPC { Message = string.Format("Function {0} is not found", body.Method), Code = -40002 }));
                    }
            }
            return Json(new ResJsonRPC()
            {
                Key = body.Params.Key,
                JsonRPC = body.JsonRPC,
                Method = body.Method,
                Result = result
            }
            );
        }

        private ResJsonRPCError GetError(string key, string jsonRPC, ErrorJsonRPC error)
        {
            return new ResJsonRPCError()
            {
                Key = key,
                JsonRPC = jsonRPC,
                Error = error
            };
        }

        private int? SetM(string k, int x)
        {
            HttpContext.Application[k] = x;
            return GetM(k);
        }

        private int? GetM(string k)
        {
            object result = HttpContext.Application[k];
            if (result == null)
                return null;
            else
                return int.Parse(result.ToString());
        }

        private int? AddM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Application[k] = value == null ? x : value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Application[k] = value == null ? x : value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Application[k] = value == null ? x : value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Application[k] = value == null ? x : value / x;
            return GetM(k);
        }

        private void ErrorExit()
        {
            HttpContext.Application.Clear();
            ignoreMethods = true;
        }
    }
}