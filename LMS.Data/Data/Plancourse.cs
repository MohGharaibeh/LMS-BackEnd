using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Plancourse
{
    public decimal Plancourseid { get; set; }

    public decimal? Ordernumber { get; set; }

    public string? Prerequest { get; set; }

    public DateTime? Enddate { get; set; }

    public DateTime? Startdate { get; set; }

    public decimal? Planid { get; set; }

    public decimal? Courseid { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Plan? Plan { get; set; }
}
