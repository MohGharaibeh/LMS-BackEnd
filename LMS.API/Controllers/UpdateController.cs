using LMS.Core.Service;
using LMS.Data.Data;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UpdateController : ControllerBase
{
    private readonly IUpdateService _updateService;

    public UpdateController(IUpdateService updateService)
    {
        _updateService = updateService;
    }

    [HttpPut]
    [Route("Assignments")]
    public async Task Assignments(Assignment assignment)
    {
        await _updateService.Assignments(assignment);
    }

    [HttpPut]
    [Route("Attendances")]
    public async Task Attendances(Attendance attendance)
    {
        await _updateService.Attendances(attendance);
    }

    [HttpPut]
    [Route("Courses")]
    public async Task Courses(Course course)
    {
        await _updateService.Courses(course);
    }

    [HttpPut]
    [Route("Enrollments")]
    public async Task Enrollments(Enrollment enrollment)
    {
        await _updateService.Enrollments(enrollment);
    }

    [HttpPut]
    [Route("Periods")]
    public async Task Periods(Period period)
    {
        await _updateService.Periods(period);
    }

    [HttpPut]
    [Route("Plans")]
    public async Task Plans(Plan plan)
    {
        await _updateService.Plans(plan);
    }

    [HttpPut]
    [Route("Plancourses")]
    public async Task Plancourses(Plancourse plancourse)
    {
        await _updateService.Plancourses(plancourse);
    }

    [HttpPut]
    [Route("Programs")]
    public async Task Programs(LMS.Data.Data.Program program)
    {
        await _updateService.Programs(program);
    }

    [HttpPut]
    [Route("Sections")]
    public async Task Sections(LMS.Data.Data.Section section)
    {
        await _updateService.Sections(section);
    }

    [HttpPut]
    [Route("Userassignments")]
    public async Task Userassignments(Userassignment userassignment)
    {
        await _updateService.Userassignments(userassignment);
    }

    [HttpPut]
    [Route("Users")]
    public async Task Users(User user)
    {
        await _updateService.Users(user);
    }
}
