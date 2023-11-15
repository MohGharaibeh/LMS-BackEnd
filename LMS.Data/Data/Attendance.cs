using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Attendance
{
    public decimal Attendenceid { get; set; }

    public DateTime? Attendancedate { get; set; }

    public string? Absente { get; set; }

    public decimal? Sectionid { get; set; }

    public decimal? Userid { get; set; }

    public virtual Section? Section { get; set; }

    public virtual User? User { get; set; }
}
