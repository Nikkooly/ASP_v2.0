using AutoMapper;

namespace StudentsService.Models.Students
{
    public static class StudentsHelper
    {
        private static Mapper _mapper { get; set; }

        static StudentsHelper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentInfo, Database.Models.Students>();
                cfg.CreateMap<Database.Models.Students, StudentInfo>();
            });
            _mapper = new Mapper(config);
        }

        public static StudentInfo ToDto(this Database.Models.Students student)
        {
            if (student == null)
                return null;
            var studentInfo = _mapper.Map<Database.Models.Students, StudentInfo>(student);

            studentInfo.Hateoas = Hateoas.GetStudentHateoas(student.Id);
            return studentInfo;
        }

        public static Database.Models.Students ToEntity(this StudentInfo student)
        {
            if (student == null)
                return null;

            return _mapper.Map<StudentInfo, Database.Models.Students>(student);
        }

        public static Database.Models.Students ToEntity(this StudentInfo student, Database.Models.Students students)
        {
            if (student == null)
                return null;

            return _mapper.Map<StudentInfo, Database.Models.Students>(student, students);
        }
    }
}
