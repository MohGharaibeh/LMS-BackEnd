using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Core.Repository;

public interface IDeleteRepository
{
    Task<int> Assignments(int id);
    Task<int> Attendances(int id);
    Task<int> Courses(int id);
    Task<int> Enrollments(int id);
    Task<int> Periods(int id);
    Task<int> Plancourses(int id);
    Task<int> Plans(int id);
    Task<int> Programs(int id);
    Task<int> Sections(int id);
    Task<int> Userassignments(int id);
    Task<int> Users(int id);
}
