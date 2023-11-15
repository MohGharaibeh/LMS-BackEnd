using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Section
{
    public decimal Sectionid { get; set; }

    public string? Name { get; set; }

    public DateTime? Time { get; set; }

    public decimal? Courseid { get; set; }

    public decimal? Userid { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Course? Course { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual User? User { get; set; }
}
