using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsService.Models.Students
{
    public class StudentsFilter
    {
        public int? StudentId { get; set; }
        public bool? SortByName { get; set; }
        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public int? MinId { get; set; }
        public int? MaxId { get; set; }
        public string Like { get; set; }
        public string GlobalLike { get; set; }
        public string SelectColumns { get; set; }
    }
}
