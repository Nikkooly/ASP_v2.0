using System.Web.Http;
using System.Web.Mvc;
using System.Web.SessionState;
using lab8.Models;

namespace lab8.Controllers
{
    public class JRServiceController : Controller, IRequiresSessionState
    {
        //private static bool ignoreMethods = false;

        [System.Web.Http.HttpPost]
        public JsonResult Multi([FromBody] ReqJsonRPC[] body)
        {
            var length = body.Length;
            var result = new JsonResult[length];

            for (var i = 0; i < length; i++)
                result[i] = Single(body[i]);

            return Json(result);
        }

        [System.Web.Http.HttpPost]
        public JsonResult Single(ReqJsonRPC body)
        {
            var c = HttpContext.Session["error"];
            if (c != null && (bool)c)
                return Json(GetError(body.Params.Key, body.JsonRPC, new ErrorJsonRPC { Message = "Methods are don't available", Code = -40001 }));

            var method = body.Method;
            var param = body.Params;
            var key = param.Key;
            if(key == null && method != "ErrorExit")
                return Json(GetError(null, body.JsonRPC,
                    new ErrorJsonRPC { Message = "Key not specified", Code = -40001 }));
            var value = int.Parse(string.IsNullOrEmpty(param.Value) ? "0" : param.Value); // default value = 0
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
                    return Json(GetError(body.Params.Key, body.JsonRPC, new ErrorJsonRPC
                    {
                        Message =
                            $"Function {body.Method} is not found",
                        Code = -40002
                    }));
                }
            }

            return Json(new ResJsonRPC
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
            return new ResJsonRPCError
            {
                Key = key,
                JsonRPC = jsonRPC,
                Error = error
            };
        }

        private int? SetM(string k, int x)
        {
            HttpContext.Session[k] = x;
            return GetM(k);
        }

        private int? GetM(string k)
        {
            var result = HttpContext.Session[k];
            if (result == null)
                return null;
            return int.Parse(result.ToString());
        }

        private int? AddM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value / x;
            return GetM(k);
        }

        private void ErrorExit()
        {
            HttpContext.Session.Clear();
            HttpContext.Session["error"] = true;
            //ignoreMethods = true;
        }
    }
}