using LMS.Core.Service;
using LMS.Data.Data;
using LMS.Data.DTOs;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetIdController : ControllerBase
    {
        private readonly IGetIdService _getIdService;

        public GetIdController(IGetIdService getIdService)
        {
            _getIdService = getIdService;
        }

        [Route("Assignments/{id}")]
        public async Task<List<Assignment>> Assignments(int id)
        {
            return await _getIdService.Assignments(id);
        }

        [HttpGet]
        [Route("Attendances/{id}")]
        public async Task<Attendance> Attendances(int id)
        {
            return await _getIdService.Attendances(id);
        }

        [HttpGet]
        [Route("Courses/{id}")]
        public async Task<Course> Courses(int id)
        {
            return await _getIdService.Courses(id);
        }

        [HttpGet]
        [Route("Enrollments/{id}")]
        public async Task<Enrollment> Enrollments(int id)
        {
            return await _getIdService.Enrollments(id);
        }
        [HttpGet]
        [Route("EnrollmentsBySection/{id}")]
        public async Task<List<Enrollment>> EnrollmentsBySection(int id)
        {
            return await _getIdService.EnrollmentsBySection(id);
        }

        [HttpGet]
        [Route("Periods/{id}")]
        public async Task<Period> Periods(int id)
        {
            return await _getIdService.Periods(id);
        }

        [HttpGet]
        [Route("Plancourses/{id}")]
        public async Task<Plancourse> Plancourses(int id)
        {
            return await _getIdService.Plancourses(id);
        }

        [HttpGet]
        [Route("Plans/{id}")]
        public async Task<Plan> Plans(int id)
        {
            return await _getIdService.Plans(id);
        }

        [HttpGet]
        [Route("Programs/{id}")]
        public async Task<LMS.Data.Data.Program> Programs(int id)
        {
            return await _getIdService.Programs(id);
        }

        [HttpGet]
        [Route("Sections/{id}")]
        public async Task<Section> Sections(int id)
        {
            return await _getIdService.Sections(id);
        }

        [HttpGet]
        [Route("Userassignments/{id}")]
        public async Task<Userassignment> Userassignments(int id)
        {
            return await _getIdService.Userassignments(id);
        }
        [HttpPost]
        [Route("GetUserGrades/")]
        public async Task<List<StudentAssingmentsDTO>> GetUserGrades([FromBody] UserAssignmentsRequestDTO request)
        {
            return await _getIdService.GetUserGrades(request.SectionId, request.UserId);
        }


        [HttpGet]
        [Route("GetDistinctAttendanceDatesForSection/{id}")]
        public async Task<List<DateTime>> GetDistinctAttendanceDatesForSection(int id)
        {
            return await _getIdService.GetDistinctAttendanceDatesForSection(id);
        }



        [HttpPost("GetUserAssignmentsBySectionId")]
        public async Task<IEnumerable<StudentAssingmentsDTO>> GetUserAssignmentsBySectionId([FromBody] UserAssignmentsRequestDTO request)
        {
            return await _getIdService.GetUserAssignmentsBySectionId(request.SectionId, request.UserId);
        }


        [HttpGet]
        [Route("Users/{id}")]
        public async Task<User> Users(int id)
        {
            return await _getIdService.Users(id);
        }

    }
}
