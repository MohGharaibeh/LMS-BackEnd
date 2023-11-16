using LMS.Data.Data;

namespace LMS.Core.Repository;

public interface ICreateRepository
{
    Task Assignments(Assignment assignment);
    Task Attendances(Attendance attendance);
    Task Courses(Course course);
    Task Enrollments(Enrollment enrollment);
    Task Periods(Period period);
    Task Plancourses(Plancourse plancourse);
    Task Plans(Plan plan);
    Task Programs(Program program);
    Task Sections(Section section);
    Task Userassignments(Userassignment userassignment);
    Task Users(User user);
    Task<User> LoginUsers(User user);
}
