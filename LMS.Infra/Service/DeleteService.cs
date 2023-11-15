using LMS.Core.Repository;
using LMS.Core.Service;

namespace LMS.Infra.Service;

public class DeleteService : IDeleteService
{
    private readonly IDeleteRepository _deleteRepository;

    public DeleteService(IDeleteRepository deleteRepository)
    {
        _deleteRepository = deleteRepository;
    }

    public async Task<int> Assignments(int id)
    {
        return await _deleteRepository.Assignments(id);
    }

    public async Task<int> Attendances(int id)
    {
        return await _deleteRepository.Attendances(id);
    }

    public async Task<int> Courses(int id)
    {
        return await _deleteRepository.Courses(id);
    }

    public async Task<int> Enrollments(int id)
    {
        return await _deleteRepository.Enrollments(id);
    }

    public async Task<int> Periods(int id)
    {
        return await _deleteRepository.Periods(id);
    }

    public async Task<int> Plancourses(int id)
    {
        return await _deleteRepository.Plancourses(id);
    }

    public async Task<int> Plans(int id)
    {
        return await _deleteRepository.Plans(id);
    }

    public async Task<int> Programs(int id)
    {
        return await _deleteRepository.Programs(id);
    }

    public async Task<int> Sections(int id)
    {
        return await _deleteRepository.Sections(id);
    }

    public async Task<int> Userassignments(int id)
    {
        return await _deleteRepository.Userassignments(id);
    }

    public async Task<int> Users(int id)
    {
        return await _deleteRepository.Users(id);
    }
}
