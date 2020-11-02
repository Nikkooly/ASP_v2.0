using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StudentsService.Models
{
    [DataContract]
    public class Hateoas
    {
        [DataMember]
        public string Href { get; set; }
        [DataMember]
        public string Rel { get; set; }

        public Hateoas(string href, string rel)
        {
            Href = href;
            Rel = rel;
        }

        public static Hateoas GetStudentHateoas(int idStudent)
        {
            return new Hateoas($"http://localhost:59508/students/student/{idStudent}.json","student:" + idStudent);
        }

        public static Hateoas GetErrorHateoas(string id, string message)
        {
            return new Hateoas($"http://localhost:59508/Errors/error/{id}", message);
        }
    }
}
