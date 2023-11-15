using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Program
{
    public decimal Programid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Periodid { get; set; }

    public virtual Period? Period { get; set; }

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();
}
