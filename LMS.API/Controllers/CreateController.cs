using LMS.Core.Service;
using LMS.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CreateController : ControllerBase
{
    private readonly ICreateService _createService;

    public CreateController(ICreateService createService)
    {
        _createService = createService;
    }

    [HttpPost]
    [Route("Assignments")]
    public async Task Assignments(Assignment assignment)
    {
        await _createService.Assignments(assignment);
    }

    [HttpPost]
    [Route("Attendances")]
    public async Task Attendances(Attendance attendance)
    {
        await _createService.Attendances(attendance);
    }

    [HttpPost]
    [Route("Courses")]
    public async Task Courses(Course course)
    {
        await _createService.Courses(course);
    }

    [HttpPost]
    [Route("Enrollments")]
    public async Task Enrollments(Enrollment enrollment)
    {
        await _createService.Enrollments(enrollment);
    }

    [HttpPost]
    [Route("Periods")]
    public async Task Periods(Period period)
    {
        await _createService.Periods(period);
    }

    [HttpPost]
    [Route("Plans")]
    public async Task Plans(Plan plan)
    {
        await _createService.Plans(plan);
    }

    [HttpPost]
    [Route("Plancourses")]
    public async Task Plancourses(Plancourse plancourse)
    {
        await _createService.Plancourses(plancourse);
    }

    [HttpPost]
    [Route("Programs")]
    public async Task Programs(LMS.Data.Data.Program program)
    {
        await _createService.Programs(program);
    }

    [HttpPost]
    [Route("Sections")]
    public async Task Sections(LMS.Data.Data.Section section)
    {
        await _createService.Sections(section);
    }

    [HttpPost]
    [Route("Userassignments")]
    public async Task Userassignments(Userassignment userassignment)
    {
        await _createService.Userassignments(userassignment);
    }

    [HttpPost]
    [Route("Users")]
    public async Task Users(User user)
    {
        await _createService.Users(user);
    }

    [Route("uploadUserImage")]
    [HttpPost]
    public User UploadUserIMage()
    {
        var file = Request.Form.Files[0];
        var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var fullPath = Path.Combine("Images", fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }
        User item = new User();
        item.Imagepath = fileName;
        return item;
    }

    [Route("uploadCourseImage")]
    [HttpPost]
    public Course UploadCourseIMage()
    {
        var file = Request.Form.Files[0];
        var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var fullPath = Path.Combine("Images", fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }
        Course item = new Course();
        item.Imagepath = fileName;
        return item;
    }
}
