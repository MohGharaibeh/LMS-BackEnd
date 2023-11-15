using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Data.Data;

namespace LMS.Infra.Service;

public class UpdateService : IUpdateService
{
    private readonly IUpdateRepository _repository;

    public UpdateService(IUpdateRepository repository)
    {
        _repository = repository;
    }

    public async Task Assignments(Assignment assignment)
    {
        await _repository.Assignments(assignment);
    }

    public async Task Attendances(Attendance attendance)
    {
        await _repository.Attendances(attendance);
    }

    public async Task Courses(Course course)
    {
        await _repository.Courses(course);
    }

    public async Task Enrollments(Enrollment enrollment)
    {
        await _repository.Enrollments(enrollment);
    }

    public async Task Periods(Period period)
    {
        await _repository.Periods(period);
    }

    public async Task Plancourses(Plancourse plancourse)
    {
        await _repository.Plancourses(plancourse);
    }

    public async Task Plans(Plan plan)
    {
        await _repository.Plans(plan);
    }

    public async Task Programs(Program program)
    {
        await _repository.Programs(program);
    }

    public async Task Sections(Section section)
    {
        await _repository.Sections(section);
    }

    public async Task Userassignments(Userassignment userassignment)
    {
        await _repository.Userassignments(userassignment);
    }

    public async Task Users(User user)
    {
        await _repository.Users(user);
    }
}
