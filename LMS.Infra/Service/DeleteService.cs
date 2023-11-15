using LMS.Core.Repository;
using LMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Service;

public class DeleteService : IDeleteService
{
    private readonly IDeleteRepository _deleteRepository;

    public DeleteService(IDeleteRepository deleteRepository)
    {
        _deleteRepository = deleteRepository;
    }

    public Task<int> Assignments(int id)
    {
        return _deleteRepository.Assignments(id);
    }

    public Task<int> Attendances(int id)
    {
        return _deleteRepository.Attendances(id);
    }

    public Task<int> Courses(int id)
    {
        return _deleteRepository.Courses(id);
    }

    public Task<int> Enrollments(int id)
    {
        return _deleteRepository.Enrollments(id);
    }

    public Task<int> Periods(int id)
    {
        return _deleteRepository.Periods(id);
    }

    public Task<int> Plancourses(int id)
    {
        return _deleteRepository.Plancourses(id);
    }

    public Task<int> Plans(int id)
    {
        return _deleteRepository.Plans(id);
    }

    public Task<int> Programs(int id)
    {
        return _deleteRepository.Programs(id);
    }

    public Task<int> Sections(int id)
    {
        return _deleteRepository.Sections(id);
    }

    public Task<int> Userassignments(int id)
    {
        return _deleteRepository.Userassignments(id);
    }

    public Task<int> Users(int id)
    {
        return _deleteRepository.Users(id);
    }
}
