using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service;

public class GetIdService : IGetIdService
{
    private readonly IGetIdRepository _getId;

    public GetIdService(IGetIdRepository getId)
    {
        _getId = getId;
    }

    public Task<Assignment> Assignments(int id)
    {
        return _getId.Assignments(id);
    }

    public Task<Attendance> Attendances(int id)
    {
        return _getId.Attendances(id);
    }

    public Task<Course> Courses(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Enrollment> Enrollments(int id)
    {
        return _getId.Enrollments(id);
    }

    public Task<Period> Periods(int id)
    {
        return _getId.Periods(id);
    }

    public Task<Plancourse> Plancourses(int id)
    {
        return _getId.Plancourses(id);
    }

    public Task<Plan> Plans(int id)
    {
        return _getId.Plans(id);
    }

    public Task<Program> Programs(int id)
    {
        return _getId.Programs(id);
    }

    public Task<Section> Sections(int id)
    {
        return _getId.Sections(id);
    }

    public Task<Userassignment> Userassignments(int id)
    {
        return _getId.Userassignments(id);
    }

    public Task<User> Users(int id)
    {
        return _getId.Users(id);
    }
}
