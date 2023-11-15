using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Data.Data;

namespace LMS.Infra.Service;

public class GetService : IGetService
{
    private readonly IGetRepository _getRepository;
    public GetService(IGetRepository getRepository)
    {
        _getRepository = getRepository;
    }
    public Task<List<Assignment>> Assignments()
    {
        return _getRepository.Assignments();
    }

    public Task<List<Attendance>> Attendances()
    {
        return _getRepository.Attendances();
    }

    public Task<List<Course>> Courses()
    {
        return _getRepository.Courses();
    }

    public Task<List<Enrollment>> Enrollments()
    {
        return _getRepository.Enrollments();
    }

    public Task<List<Period>> Periods()
    {
        return _getRepository.Periods();
    }

    public Task<List<Plancourse>> Plancourses()
    {
        return _getRepository.Plancourses();
    }

    public Task<List<Plan>> Plans()
    {
        return _getRepository.Plans();
    }

    public Task<List<Program>> Programs()
    {
        return _getRepository.Programs();
    }

    public Task<List<Section>> Sections()
    {
        return _getRepository.Sections();
    }

    public Task<List<Userassignment>> Userassignments()
    {
        return _getRepository.Userassignments();
    }

    public Task<List<User>> Users()
    {
        return _getRepository.Users();
    }
}
