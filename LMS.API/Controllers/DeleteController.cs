using LMS.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("[controller]")]
[ApiController]
public class DeleteController : ControllerBase
{
    private readonly IDeleteService _deleteService;

    public DeleteController(IDeleteService deleteService)
    {
        _deleteService = deleteService;
    }

    [HttpDelete]
    [Route("Assignments/{id}")]
    public async Task<int> Assignments(int id)
    {
        return await _deleteService.Assignments(id);
    }

    [HttpDelete]
    [Route("Attendances/{id}")]
    public async Task<int> Attendances(int id)
    {
        return await _deleteService.Attendances(id);
    }

    [HttpDelete]
    [Route("Courses/{id}")]
    public async Task<int> Courses(int id)
    {
        return await _deleteService.Courses(id);
    }

    [HttpDelete]
    [Route("Enrollments/{id}")]
    public async Task<int> Enrollments(int id)
    {
        return await _deleteService.Enrollments(id);
    }

    [HttpDelete]
    [Route("Periods/{id}")]
    public async Task<int> Periods(int id)
    {
        return await _deleteService.Periods(id);
    }

    [HttpDelete]
    [Route("Plancourses/{id}")]
    public async Task<int> Plancourses(int id)
    {
        return await _deleteService.Plancourses(id);
    }

    [HttpDelete]
    [Route("Plans/{id}")]
    public async Task<int> Plans(int id)
    {
        return await _deleteService.Plans(id);
    }

    [HttpDelete]
    [Route("Programs/{id}")]
    public async Task<int> Programs(int id)
    {
        return await _deleteService.Programs(id);
    }

    [HttpDelete]
    [Route("Sections/{id}")]
    public async Task<int> Sections(int id)
    {
        return await _deleteService.Sections(id);
    }

    [HttpDelete]
    [Route("Userassignments/{id}")]
    public async Task<int> Userassignments(int id)
    {
        return await _deleteService.Userassignments(id);
    }

    [HttpDelete]
    [Route("Users/{id}")]
    public async Task<int> Users(int id)
    {
        return await _deleteService.Users(id);
    }
}
