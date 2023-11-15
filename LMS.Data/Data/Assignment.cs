using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Assignment
{
    public decimal Assignmentid { get; set; }

    public string? Content { get; set; }

    public DateTime? Deadline { get; set; }

    public string? Name { get; set; }

    public decimal? Grade { get; set; }

    public decimal? Sectionid { get; set; }

    public virtual Section? Section { get; set; }

    public virtual ICollection<Userassignment> Userassignments { get; set; } = new List<Userassignment>();
}
