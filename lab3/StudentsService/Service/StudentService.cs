using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using StudentsService.Models.Students;

namespace StudentsService.Service
{
    public class StudentService : IStudentService
    {
        private readonly DatabaseContext _context;

        public StudentService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<StudentInfo> GetStudentAsync(StudentsFilter filter)
        {
            if (!filter.StudentId.HasValue)
                return null;
            return (await _context.Students.FirstOrDefaultAsync(x => x.Id == filter.StudentId.Value)).ToDto();
        }

        public async Task<IEnumerable<StudentInfo>> GetStudentsAsync(StudentsFilter filter)
        {
            return (await _context.Students.Where(filter).Sort(filter).ToListAsync()).Skip(filter).Select(x=>x.ToDto());
        }

        public async Task<StudentInfo> UpdateStudentAsync(StudentInfo student)
        {
            if (student == null)
                return null;
            var studentFromContext = await _context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
            if (studentFromContext == null)
                return null;
            student.ToEntity(studentFromContext);
            await _context.SaveChangesAsync();
            return studentFromContext.ToDto();
        }

        public async Task<bool> DeleteStudentAsync(StudentsFilter filter)
        {
            if (!filter.StudentId.HasValue)
                return false;
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == filter.StudentId);
            if (student == null)
                return false;
            _context.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StudentInfo> AddStudentAsync(StudentInfo student)
        {
            var entity = student.ToEntity();
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDto();
        }
    }
}
