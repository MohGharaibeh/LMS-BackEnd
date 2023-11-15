using LMS.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service;

public interface ICreateService
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
}
