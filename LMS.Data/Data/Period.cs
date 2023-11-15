using System;
using System.Collections.Generic;

namespace LMS.Data.Data;

public partial class Period
{
    public decimal Periodid { get; set; }

    public string? Name { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();
}
