using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.DTOs;

public class SectionForInstructor
{
    public decimal? SectionId { get; set; }
    public string Name { get; set; }
    public DateTime Time { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    public string CourseName { get; set; }
}
