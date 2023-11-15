using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Course
{
    public decimal Courseid { get; set; }

    public string? Name { get; set; }
    public string? Imagepath { get; set; }


    public virtual ICollection<Plancourse> Plancourses { get; set; } = new List<Plancourse>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
