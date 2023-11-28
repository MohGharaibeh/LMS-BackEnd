using LMS.Data.Data;
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

        public string? Fullname { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Phonenumber { get; set; }

        public string? Imagepath { get; set; }

        public string? Gender { get; set; }

        public decimal? Roleid { get; set; }

        public decimal? Planid { get; set; }

        public string? Content { get; set; }

        public DateTime? Deadline { get; set; }

        public string? Name { get; set; }

        public decimal? Grade { get; set; }

        public decimal? Sectionid { get; set; }

        public decimal Enrollmentid { get; set; }

        public string? Ispassed { get; set; }

        public decimal? Totalmark { get; set; }



    }
}
