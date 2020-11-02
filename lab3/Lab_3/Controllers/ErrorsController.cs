using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        // GET: api/Errors/5
        [HttpGet("error/{id}")]
        public object Get(int id)
        {
            switch (id)
            {
                case 400:
                    return Ok(new { id = 400, message = "Bad request" });
                case 404:
                    return Ok(new { id = 404, message = "Student is not found" });
                default:
                    return Ok(new { id = 500, message = "Server error" });
            }
        }
    }
}
