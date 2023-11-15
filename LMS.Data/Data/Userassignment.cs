
namespace LMS.Data.Data;

public partial class Userassignment
{
    public decimal Userassignmentid { get; set; }

    public decimal? Mark { get; set; }

    public string? Submitcontent { get; set; }

    public decimal? Assignmentid { get; set; }

    public decimal? Userid { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual User? User { get; set; }
}
