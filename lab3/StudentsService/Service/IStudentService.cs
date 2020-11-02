using System.Collections.Generic;
using System.Threading.Tasks;
using StudentsService.Models.Students;

namespace StudentsService.Service
{
    public interface IStudentService
    {
        Task<StudentInfo> GetStudentAsync(StudentsFilter filter);
        Task<IEnumerable<StudentInfo>> GetStudentsAsync(StudentsFilter filter);
        Task<StudentInfo> UpdateStudentAsync(StudentInfo student);
        Task<bool> DeleteStudentAsync(StudentsFilter filter);
        Task<StudentInfo> AddStudentAsync(StudentInfo student);
    }
}
