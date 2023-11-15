using LMS.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service;

public interface IGetIdService
{
    Task<Assignment> Assignments(int id);
    Task<Attendance> Attendances(int id);
    Task<Course> Courses(int id);
    Task<Enrollment> Enrollments(int id);
    Task<Period> Periods(int id);
    Task<Plancourse> Plancourses(int id);
    Task<Plan> Plans(int id);
    Task<Program> Programs(int id);
    Task<Section> Sections(int id);
    Task<Userassignment> Userassignments(int id);
    Task<User> Users(int id);
}
