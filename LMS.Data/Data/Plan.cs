using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Plan
{
    public decimal Planid { get; set; }

    public string? Description { get; set; }

    public decimal? Programid { get; set; }

    public virtual ICollection<Plancourse> Plancourses { get; set; } = new List<Plancourse>();

    public virtual Program? Program { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
