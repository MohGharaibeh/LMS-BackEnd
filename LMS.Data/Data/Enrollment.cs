using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Enrollment
{
    public decimal Enrollmentid { get; set; }

    public string? Ispassed { get; set; }

    public decimal? Totalmark { get; set; }

    public decimal? Userid { get; set; }

    public decimal? Sectionid { get; set; }

    public virtual Section? Section { get; set; }

    public virtual User? User { get; set; }
}
