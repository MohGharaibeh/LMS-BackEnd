using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.DTOs
{
    public class StudentAssingmentsDTO
    {
        public decimal Userassignmentid { get; set; }

        public decimal? Mark { get; set; }

        public string? Submitcontent { get; set; }

        public decimal? Assignmentid { get; set; }

        public decimal? Userid { get; set; }


        public string? Content { get; set; }

        public DateTime? Deadline { get; set; }

        public string? Name { get; set; }

        public decimal? Grade { get; set; }

        public decimal? Sectionid { get; set; }
    }
}
