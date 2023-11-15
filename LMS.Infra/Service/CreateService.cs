using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Data.Data;


namespace LMS.Infra.Service;

public class CreateService : ICreateService
{
    private readonly ICreateRepository _createRepository;

    public CreateService(ICreateRepository createRepository)
    {
        _createRepository = createRepository;
    }

    public async Task Assignments(Assignment assignment)
    {
        await _createRepository.Assignments(assignment);
    }

    public async Task Attendances(Attendance attendance)
    {
        await _createRepository.Attendances(attendance);
    }

    public async Task Courses(Course course)
    {
        await _createRepository.Courses(course);
    }

    public async Task Enrollments(Enrollment enrollment)
    {
        await _createRepository.Enrollments(enrollment);
    }

    public async Task Periods(Period period)
    {
        await _createRepository.Periods(period);
    }

    public async Task Plancourses(Plancourse plancourse)
    {
        await _createRepository.Plancourses(plancourse);
    }

    public async Task Plans(Plan plan)
    {
        await _createRepository.Plans(plan);
    }

    public async Task Programs(Program program)
    {
        await _createRepository.Programs(program);
    }

    public async Task Sections(Section section)
    {
        await _createRepository.Sections(section);
    }

    public async Task Userassignments(Userassignment userassignment)
    {
        await _createRepository.Userassignments(userassignment);
    }

    public async Task Users(User user)
    {
        await _createRepository.Users(user);
    }
}
