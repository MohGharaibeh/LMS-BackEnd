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
    public async Task<List<Assignment>> Assignments()
    {
        return await _getRepository.Assignments();
    }

    public async Task<List<Attendance>> Attendances()
    {
        return await _getRepository.Attendances();
    }

    public async Task<List<Course>> Courses()
    {
        return await _getRepository.Courses();
    }

    public async Task<List<Enrollment>> Enrollments()
    {
        return await _getRepository.Enrollments();
    }

    public async Task<List<Period>> Periods()
    {
        return await _getRepository.Periods();
    }

    public async Task<List<Plancourse>> Plancourses()
    {
        return await _getRepository.Plancourses();
    }

    public async Task<List<Plan>> Plans()
    {
        return await _getRepository.Plans();
    }

    public async Task<List<Program>> Programs()
    {
        return await _getRepository.Programs();
    }

    public async Task<List<Section>> Sections()
    {
        return await _getRepository.Sections();
    }

    public async Task<List<Userassignment>> Userassignments()
    {
        return await _getRepository.Userassignments();
    }

    public async Task<List<User>> Users()
    {
        return await _getRepository.Users();
    }

    public async Task<List<Section>> SectionForInstructor(int userId)
    {
        return await _getRepository.SectionForInstructor(userId);
    }
}
