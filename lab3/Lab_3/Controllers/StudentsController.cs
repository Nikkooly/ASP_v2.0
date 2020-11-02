using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsService.Models;
using StudentsService.Models.Students;
using StudentsService.Service;

namespace Lab_3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET students
        [HttpGet("get.{format}"), FormatFilter]
        public async Task<IEnumerable<object>> GetStudentsAsync([FromQuery] StudentsFilter filter)
        {
            var students = await _studentService.GetStudentsAsync(filter);
            var selectedColumns = filter.SelectColumns?.Split(",");
            if (selectedColumns?.Any() != true)
                return students;
            return students.Select(x=>x.GetDynamicFields(selectedColumns));
        }

        // GET students/5
        [HttpGet]
        [Route("student/{id}.{format}"), FormatFilter]
        public async Task<object> GetStudentByIdAsync(int id)
        {
            if(id == 0)
                return Hateoas.GetErrorHateoas("400", "Bad request, please enter id student");
            var result = await _studentService.GetStudentAsync(new StudentsFilter() { StudentId = id });
            if (result == null)
                return Hateoas.GetErrorHateoas("404", "error-404");
            return result;
        }

        // POST students
        [HttpPost]
        [Route("add.{format}"), FormatFilter]
        public async Task<object> AddStudentAsync(StudentInfo student)
        {
            var result = await _studentService.AddStudentAsync(student);
            if (result == null)
                return Hateoas.GetErrorHateoas("400", "error-400");
            return result;
        }

        // PUT students/5
        [HttpPut]
        [Route("update.{format}"), FormatFilter]
        public async Task<object> UpdateStudentAsync(StudentInfo student)
        {
            var result = await _studentService.UpdateStudentAsync(student);
            if (result == null)
                return Hateoas.GetErrorHateoas("404", "error-404");
            return result;
        }

        // DELETE students/5
        [HttpDelete]
        [Route("delete/{id}.{format}"), FormatFilter]
        public async Task<object> DeleteStudentAsync(int id)
        {
            var result = await _studentService.DeleteStudentAsync(new StudentsFilter() { StudentId = id });
            if (result == false)
                return Hateoas.GetErrorHateoas("400", "error-400");
            return Ok();
        }
    }
}
