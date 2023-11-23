using LMS.Core.Service;
using LMS.Data.Data;
using LMS.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("[controller]")]
[ApiController]
public class GetController : ControllerBase
{
    private readonly IGetService _getService;

    public GetController(IGetService getService)
    {
        _getService = getService;
    }

    [HttpGet]
    [Route("Assignments")]
    public async Task<List<Assignment>> Assignments()
    {
        return await _getService.Assignments();
    }

    [HttpGet]
    [Route("Attendances")]
    public async Task<List<Attendance>> Attendances()
    {
        return await _getService.Attendances();
    }

    [HttpGet]
    [Route("Courses")]
    public async Task<List<Course>> Courses()
    {
        return await _getService.Courses();
    }

    [HttpGet]
    [Route("Enrollments")]
    public async Task<List<Enrollment>> Enrollments()
    {
        return await _getService.Enrollments();
    }

    [HttpGet]
    [Route("Periods")]
    public async Task<List<Period>> Periods()
    {
        return await _getService.Periods();
    }

    [HttpGet]
    [Route("Plancourses")]
    public async Task<List<Plancourse>> Plancourses()
    {
        return await _getService.Plancourses();
    }

    [HttpGet]
    [Route("Plans")]
    public async Task<List<Plan>> Plans()
    {
        return await _getService.Plans();
    }

    [HttpGet]
    [Route("Programs")]
    public async Task<List<LMS.Data.Data.Program>> Programs()
    {
        return await _getService.Programs();
    }

    [HttpGet]
    [Route("Sections")]
    public async Task<List<Section>> Sections()
    {
        return await _getService.Sections();
    }

    [HttpGet]
    [Route("Userassignments")]
    public async Task<List<Userassignment>> Userassignments()
    {
        return await _getService.Userassignments();
    }



    [HttpGet]
    [Route("Users")]
    public async Task<List<User>> Users()
    {
        return await _getService.Users();
    }

    [HttpGet]
    [Route("SectionForInstructor/{userId}")]
    public async Task<List<Section>> SectionForInstructor(int userId)
    {
        return await _getService.SectionForInstructor(userId);
    }

    [HttpGet]
    [Route("SectionForTrainee/{traineeId}")]
    public async Task<User> SectionForTrainee(int traineeId)
    {
        return await _getService.SectionForTrainee(traineeId);
    }
}
