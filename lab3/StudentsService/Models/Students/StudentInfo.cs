using System.Runtime.Serialization;

namespace StudentsService.Models.Students
{
    [DataContract]
    public class StudentInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Patronymic { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public Hateoas Hateoas { get; set; }
    }
}
