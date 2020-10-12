using lab2.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public object Get()
        {
            return new ReturnMessage().Execute(ControllerContext);
        }

        // POST api/values/5
        [HttpPost]
        public void Post(int result)
        {
            new EditResult() { NumberToAdd = result }.Execute(ControllerContext);
        }

        // PUT api/values
        [HttpPut]
        public void Put(int add)
        {
            new PushStack() { NumberToAdd = add }.Execute(ControllerContext);
        }

        // DELETE api/values
        [HttpDelete]
        public void Delete()
        {
            new PopStack().Execute(ControllerContext);
        }
    }
}
