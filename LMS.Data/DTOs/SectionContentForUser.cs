
namespace LMS.Data.DTOs;

public class SectionContentForUser
{
    public decimal SectionId { get; set; }
    public string? Name { get; set; }
    public DateTime Time { get; set; }
    public decimal PlanCourseId { get; set; }
    public string? CourseName { get; set; }
    public string? InstructorName { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
}
