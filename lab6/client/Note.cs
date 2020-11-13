using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Note
    {
        public int Id { get; set; }
        public string Subj { get; set; }
        public int? Notes { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }

    }
}
