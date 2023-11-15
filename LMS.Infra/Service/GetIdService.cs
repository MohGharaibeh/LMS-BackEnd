using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Data.Data;

namespace LMS.Infra.Service;

public class GetIdService : IGetIdService
{
    private readonly IGetIdRepository _getId;

    public GetIdService(IGetIdRepository getId)
    {
        _getId = getId;
    }

    public async Task<Assignment> Assignments(int id)
    {
        return await _getId.Assignments(id);
    }

    public async Task<Attendance> Attendances(int id)
    {
        return await _getId.Attendances(id);
    }

    public async Task<Course> Courses(int id)
    {
        return await _getId.Courses(id);
    }

    public async Task<Enrollment> Enrollments(int id)
    {
        return await _getId.Enrollments(id);
    }

    public async Task<Period> Periods(int id)
    {
        return await _getId.Periods(id);
    }

    public async Task<Plancourse> Plancourses(int id)
    {
        return await _getId.Plancourses(id);
    }

    public async Task<Plan> Plans(int id)
    {
        return await _getId.Plans(id);
    }

    public async Task<Program> Programs(int id)
    {
        return await _getId.Programs(id);
    }

    public async Task<Section> Sections(int id)
    {
        return await _getId.Sections(id);
    }

    public async Task<Userassignment> Userassignments(int id)
    {
        return await _getId.Userassignments(id);
    }

    public async Task<User> Users(int id)
    {
        return await _getId.Users(id);
    }
}
