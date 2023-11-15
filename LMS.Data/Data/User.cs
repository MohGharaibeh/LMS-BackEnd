using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class User
{
    public decimal Userid { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phonenumber { get; set; }

    public string? Imagepath { get; set; }

    public string? Gender { get; set; }

    public decimal? Roleid { get; set; }

    public decimal? Planid { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Plan? Plan { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<Userassignment> Userassignments { get; set; } = new List<Userassignment>();
}
