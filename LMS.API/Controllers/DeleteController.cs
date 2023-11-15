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
    public Task<int> Assignments(int id)
    {
        return _deleteService.Assignments(id);
    }

    [HttpDelete]
    [Route("Attendances/{id}")]
    public Task<int> Attendances(int id)
    {
        return _deleteService.Attendances(id);
    }

    [HttpDelete]
    [Route("Courses/{id}")]
    public Task<int> Courses(int id)
    {
        return _deleteService.Courses(id);
    }

    [HttpDelete]
    [Route("Enrollments/{id}")]
    public Task<int> Enrollments(int id)
    {
        return _deleteService.Enrollments(id);
    }

    [HttpDelete]
    [Route("Periods/{id}")]
    public Task<int> Periods(int id)
    {
        return _deleteService.Periods(id);
    }

    [HttpDelete]
    [Route("Plancourses/{id}")]
    public Task<int> Plancourses(int id)
    {
        return _deleteService.Plancourses(id);
    }

    [HttpDelete]
    [Route("Plans/{id}")]
    public Task<int> Plans(int id)
    {
        return _deleteService.Plans(id);
    }

    [HttpDelete]
    [Route("Programs/{id}")]
    public Task<int> Programs(int id)
    {
        return _deleteService.Programs(id);
    }

    [HttpDelete]
    [Route("Sections/{id}")]
    public Task<int> Sections(int id)
    {
        return _deleteService.Sections(id);
    }

    [HttpDelete]
    [Route("Userassignments/{id}")]
    public Task<int> Userassignments(int id)
    {
        return _deleteService.Userassignments(id);
    }

    [HttpDelete]
    [Route("Users/{id}")]
    public Task<int> Users(int id)
    {
        return _deleteService.Users(id);
    }
}
