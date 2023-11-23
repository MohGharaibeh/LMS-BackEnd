using LMS.Data.Data;
using LMS.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Service;

public interface IGetIdService
{
    Task<List<Assignment>> Assignments(int id);
    Task<Attendance> Attendances(int id);
    Task<Course> Courses(int id);
    Task<Enrollment> Enrollments(int id);
    Task<Period> Periods(int id);
    Task<Plancourse> Plancourses(int id);
    Task<Plan> Plans(int id);
    Task<Program> Programs(int id);
    Task<Section> Sections(int id);

    Task<List<StudentAssingmentsDTO>> GetUserGrades(int SectionId, int UserId);

    Task<List<Enrollment>> EnrollmentsBySection(int id);


    Task<Userassignment> Userassignments(int id);

    Task<IEnumerable<StudentAssingmentsDTO>> GetUserAssignmentsBySectionId(int sectionId, int userId);

    Task<User> Users(int id);
}
